import React, { useState, useEffect, useCallback } from 'react';
import { Button, Input, Popconfirm, Space, Table } from 'antd';
import type { TablePaginationConfig, TableProps } from 'antd';
import { editarPessoa, excluirPessoa, listarPessoas } from '../../services/PessoaService';
import type { Pessoa, PessoaDto } from '../../models/PessoaDto';
import type { PagedResult } from '../../models/PagedResult';
import { EditarPessoaModal } from './EditarPessoaModal';
import { SearchOutlined } from '@ant-design/icons';

export const TablePessoas: React.FC = () => {

  const [result, setResult] = useState<PagedResult<Pessoa>>();
  const [loading, setLoading] = useState(false);
  const [current, setCurrent] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [search, setSearch] = useState('');
  const [pessoaSelecionada, setPessoaSelecionada] = useState<Pessoa | null>(null);
  const [openModal, setOpenModal] = useState(false);

  const handleOpenEditModel = (pessoa: Pessoa) => {
    setPessoaSelecionada(pessoa);
    setOpenModal(true);
  }

  const handleEdit = async (id:string, pessoaDto: PessoaDto) => {
    setLoading(true);
    try {
      await editarPessoa(id, pessoaDto);
      fetchData(current, pageSize, search);
    } finally {
      setLoading(false);
    }
  }

  const handleDelete = async (id: string) => {
    setLoading(true);
    try {
      await excluirPessoa(id);
      fetchData(current, pageSize, search);
    } finally {
      setLoading(false);
    }
  }

  const fetchData = useCallback(async (page: number, size: number, query: string) => {
    setLoading(true);
    try {
      const response = await listarPessoas(query, page, size);
      setResult(response);
    } catch (error) {
      console.error("Failed to fetch:", error);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchData(current, pageSize, search);
  }, [fetchData, current, pageSize, search]);

  const columns: TableProps<Pessoa>['columns'] = [
    { 
      title: 'Id', dataIndex: 'id', key: 'id',
      width: 240,
      ellipsis: true,
      render: (id) => (
        <span title={id}>
          {id}
        </span>
      )
    },
    { title: 'Nome', dataIndex: 'nome', key: 'nome',
      sorter: (a: Pessoa, b: Pessoa) => a.nome.localeCompare(b.nome)
     },
    { title: 'Idade', dataIndex: 'idade', key: 'idade', width: 90,
      sorter: (a: Pessoa, b: Pessoa) => a.idade - b.idade,
      defaultSortOrder: 'descend'
     },
    {
      title: 'Ações',
      key: 'action',
      width: 200,
      render: (_, record) => (
        <Space size="middle">
          <Button type='primary' onClick={() => handleOpenEditModel(record)}>
            Editar
          </Button>
          <Popconfirm
            title="Tem certeza que deseja excluir?"
            onConfirm={() => handleDelete(record.id)}
            okText= "Sim"
            cancelText="Não"
          >
            <Button danger>Excluir</Button>
          </Popconfirm>
        </Space>
      )
    }
  ];

  const handleTableChange = (newPagination: TablePaginationConfig) => {
    setCurrent(newPagination.current || 1);
    setPageSize(newPagination.pageSize || 10);
  };

  const handleSearch = (value: string) => {
    setSearch(value);
    setCurrent(1);
  }

  return (
   <Space orientation='vertical' style={{ width: '100%'}}>
      <Input
        placeholder="Pesquisar por nome"
        prefix={<SearchOutlined/>}
        allowClear
        onChange={(e) => handleSearch(e.target.value)}
        style={{maxWidth: 320}}
      />
      <EditarPessoaModal
        pessoa={pessoaSelecionada}
        open={openModal}
        onClose={() => setOpenModal(false)}
        onSave={handleEdit}
      />
      <Table
        columns={columns}
        dataSource={result?.data ?? []}
        rowKey="id"
        loading={loading}
        onChange={handleTableChange}
        pagination={{
          current: result?.metadata.currentPage ?? current,
          pageSize: result?.metadata.pageSize ?? pageSize,
          total: result?.metadata.totalCount ?? 0,
          showSizeChanger: true,}}
      />
   </Space>
  );
};