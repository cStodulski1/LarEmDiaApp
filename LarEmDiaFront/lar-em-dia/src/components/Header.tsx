import React from 'react';
import { Layout, Menu, theme } from 'antd';
import { FolderAddOutlined, HomeFilled, LaptopOutlined, SwapOutlined, UserOutlined } from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';

const { Header: AntdHeader } = Layout;

export function Header(): React.ReactElement {
  const {
    token: { colorBgContainer },
  } = theme.useToken();
  const navigate = useNavigate()

  return (
    <AntdHeader
      style={{
        display: 'flex',
        alignItems: 'center',
        padding: '0 24px',
        background: colorBgContainer,
        position: 'sticky',
        top: 0,
        zIndex: 1,
      }}
    >
      <div className="demo-logo" />
      <Menu
        theme="dark"
        mode="horizontal"
        defaultSelectedKeys={['2']}
        items={[{
            key: '1',
            icon: <HomeFilled />,
            label: 'Home',
            onClick: () => navigate('/')
            },
            {
            key: '2',
            icon: <UserOutlined />,
            label: 'Pessoa',
            children: [
              {
                key: '2.1',
                label: 'Cadastrar',
                onClick: () => navigate('/CadastroPessoa')
              },
              {
                key: '2.2',
                label: 'Listar',
                onClick: () => navigate('/ListagemPessoa')
              }
            ]  
            },
            {
            key: '3',
            icon: <FolderAddOutlined />,
            label: 'Categoria',
            children: [
              {
                key: '3.1',
                label: 'Cadastrar',
                onClick: () => navigate('/CadastroCategoria')
              },
              {
                key: '3.2',
                label: 'Listar',
                onClick: () => navigate('/ListagemCategoria')
              }
            ] 
            },
            {
            key: '4',
            icon: <SwapOutlined />,
            label: 'Transacao',
            onClick: () => navigate('/CadastroTransacao')
            },
            {
            key: '5',
            icon: <LaptopOutlined />,
            label: 'Relatorios',
            onClick: () => navigate('/ListagemTotaisPessoas')
            }
        ]}
        style={{ flex: 1, minWidth: 0, lineHeight: '64px' }}
      />
    </AntdHeader>
  );
}