import React from 'react';
import { Layout, theme } from 'antd';
import { Header } from './components/Header';
import { Toaster } from 'sonner';
import { Outlet } from 'react-router-dom';

const { Content, Footer } = Layout;

const App: React.FC = () => {
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  return (
    <>
      <Toaster richColors position="top-right"/>
      <Layout style={{ minHeight: '100vh' }}> 
        <Header/>
          <Layout
            style={{ padding: '24px 48px', background: colorBgContainer, borderRadius: borderRadiusLG }}
          >
            <Content style={{ padding: '0 24px', minHeight: 280 }}>
              <Outlet/>
            </Content>
          </Layout>
        <Footer style={{ textAlign: 'center' }}>
          Ant Design ©{new Date().getFullYear()} Created by Ant UED
        </Footer>
      </Layout>
    
    </>
  );
};

export default App;