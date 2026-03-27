import { Layout, Menu, theme } from "antd";
import { useNavigate } from "react-router-dom";
import { SwapOutlined } from '@ant-design/icons';

const { Sider : AntdSider} = Layout;

export function Sider(): React.ReactElement {
    const {
        token: { colorBgContainer },
    } = theme.useToken();
    const navigate = useNavigate()

    return (
        <AntdSider style={{background: colorBgContainer}} width={200}>
            <Menu
              mode="inline"
              defaultSelectedKeys={['1']}
              defaultOpenKeys={['sub1']}
              style={{ height: '100%' }}
              items={[
                    {
                        key: '1',
                        label: 'Pessoas',
                        children: [
                            {
                                key: '1.1',
                                label: 'Cadastrar Pessoa',
                                onClick: () => navigate('/CadastroPessoa')
                            }
                        ]
                    },
                    {
                        key: '2',
                        label: 'Categorias',
                        children: [
                            {
                                key: '2.1',
                                label: 'Cadastrar Categoria',
                                onClick: () => navigate('/CadastroCategoria')
                            }
                        ]
                    },
                    {
                    key: '3',
                    icon: <SwapOutlined />,
                    label: 'Transações',
                    children: [
                            {
                            key: '3.1',
                            label: 'Cadastrar transação',
                            onClick: () => navigate('/CadastroTransacao')
                            }
                        ]
                    }
                ]}
            />
        </AntdSider>
    )
}
