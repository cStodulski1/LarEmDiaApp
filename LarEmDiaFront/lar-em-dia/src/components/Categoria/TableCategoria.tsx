import React, { useState, useEffect, useCallback } from 'react';
import { Input, Select, Space, Table } from 'antd';
import type { TablePaginationConfig, TableProps } from 'antd';
import type { PagedResult } from '../../models/PagedResult';
import { SearchOutlined } from '@ant-design/icons';
import type { Categoria } from '../../models/Categoria';
import { listarCategorias } from '../../services/CategoriaService';

export const TableCategoria: React.FC = () => {

  const [result, setResult] = useState<PagedResult<Categoria>>();
  const [loading, setLoading] = useState(false);
  const [current, setCurrent] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [search, setSearch] = useState('');
  const [finalidade, setFinalidade] = useState('Ambas');

  const fetchData = useCallback(async (finalidade: string, query: string, page: number, size: number) => {
    setLoading(true);
    try {
      const response = await listarCategorias(query, finalidade, page, size);
      setResult(response);
    } catch (error) {
      console.error("Failed to fetch:", error);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchData(finalidade, search, current, pageSize);
  }, [fetchData, finalidade, search, current, pageSize]);

  const columns: TableProps<Categoria>['columns'] = [
    { 
      title: 'Id', dataIndex: 'categoriaId', key: 'id',
      width: 240,
      ellipsis: true,
      render: (id) => (
        <span title={id}>
          {id}
        </span>
      )
    },
    { 
        title: 'Descrição', dataIndex: 'descricao', key: 'descricao',
        sorter: (a: Categoria, b: Categoria) => a.descricao.localeCompare(b.descricao)
     },
     {title: 'Finalidade', dataIndex: 'finalidade', key: 'finalidade'}
  ];

  const handleTableChange = (newPagination: TablePaginationConfig) => {
    setCurrent(newPagination.current || 1);
    setPageSize(newPagination.pageSize || 10);
  };

  const handleSearch = (value: string) => {
    setSearch(value);
    setCurrent(1);
  }

  const handleFinalidadeChange = (value:  string) => {
    setFinalidade(value);
    setCurrent(1);
  }

  return (
   <Space orientation='vertical' style={{ width: '100%'}}>
      <Space>
        <Input
          placeholder="Pesquisar por descrição"
          prefix={<SearchOutlined />}
          allowClear
          onChange={(e) => handleSearch(e.target.value)}
          style={{ width: 320 }}
        />
        <Select
          value={finalidade}
          onChange={handleFinalidadeChange}
          style={{ width: 160 }}
          options={[
            { value: 'Ambas', label: 'Ambas' },
            { value: 'Despesa', label: 'Despesa' },
            { value: 'Receita', label: 'Receita' },
          ]}
        />
      </Space>
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
          showSizeChanger: true
        }}
      />
   </Space>
  );
};