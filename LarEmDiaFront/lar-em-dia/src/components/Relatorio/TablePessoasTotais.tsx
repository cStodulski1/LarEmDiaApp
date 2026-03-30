import React, { useState, useEffect, useCallback } from 'react';
import { Space, Table } from 'antd';
import type { TablePaginationConfig, TableProps } from 'antd';
import type { PagedResult } from '../../models/PagedResult';
import { listarPessoasTotais, listarTotais } from '../../services/RelatorioService';
import type { PessoaTotaisDto, TotaisDto } from '../../models/PessoaTotaisDto';

export const TablePessoasTotais: React.FC = () => {

  const [result, setResult] = useState<PagedResult<PessoaTotaisDto>>();
  const [totais, setTotais] = useState<TotaisDto | null>(null);
  const [loading, setLoading] = useState(false);
  const [current, setCurrent] = useState(1);
  const [pageSize, setPageSize] = useState(10);

  const fetchData = useCallback(async (page: number, size: number) => {
    setLoading(true);
    try {
      const [response, totaisResponse] = await Promise.all([
        listarPessoasTotais(page, size),
        listarTotais(),
      ]);
      setTotais(totaisResponse)
      setResult(response);
    } catch (error) {
      console.error("Failed to fetch:", error);
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchData(current, pageSize);
  }, [fetchData, current, pageSize]);

  const columns: TableProps<PessoaTotaisDto>['columns'] = [
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
      sorter: (a: PessoaTotaisDto, b: PessoaTotaisDto) => a.nome.localeCompare(b.nome)
     },
    { title: 'Idade', dataIndex: 'idade', key: 'idade', width: 90,
      sorter: (a: PessoaTotaisDto, b: PessoaTotaisDto) => a.idade - b.idade,
      defaultSortOrder: 'descend'
     },//receita, despesas e saldo
     {title: 'Receita', dataIndex: 'valorReceita', key: 'receita'},
     {title: 'Despesas', dataIndex: 'valorDespesa', key: 'despesas'},
     {title: 'Saldo', dataIndex: 'saldo', key: 'saldo'},
  ];

  const handleTableChange = (newPagination: TablePaginationConfig) => {
    setCurrent(newPagination.current || 1);
    setPageSize(newPagination.pageSize || 10);
  };

  return (
   <Space orientation='vertical' style={{ width: '100%'}}>
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
        summary={() => (
          <Table.Summary fixed="bottom">
            <Table.Summary.Row style={{ fontWeight: 'bold', background: '#fafafa' }}>
              {/* Id + Nome + Idade columns — merged label cell */}
              <Table.Summary.Cell index={0} colSpan={3}>
                Totais
              </Table.Summary.Cell>

              <Table.Summary.Cell index={3}>
                {totais?.totalDeReceita ?? '—'}
              </Table.Summary.Cell>

              <Table.Summary.Cell index={4}>
                {totais?.totalDeDespesas ?? '—'}
              </Table.Summary.Cell>

              <Table.Summary.Cell index={5}>
                {totais?.saldoLiquido ?? '—'}
              </Table.Summary.Cell>
            </Table.Summary.Row>
          </Table.Summary>
        )}
      />
   </Space>
  );
};