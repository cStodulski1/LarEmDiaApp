// router.tsx
import { createBrowserRouter} from 'react-router-dom';
import ErrorPage from '../pages/ErrorPage';
import CadastroPessoa from '../pages/Pessoa/CadastroPessoa';
import CadastroCategoria from '../pages/Categoria/CadastroCategoria';
import { CadastroTransacao } from '../pages/Transacao/CadastroTransacao';
import App from '../App';
import ListagemPessoa from '../pages/Pessoa/ListagemPessoa';
import ListagemCategoria from '../pages/Categoria/ListagemCategoria';

const MainContent: React.FC = () => {
  return (
    <div>
      <h2>Página Principal</h2>
      <p>Selecione uma opção no menu para navegar.</p>
    </div>
  );
};


const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        errorElement: <ErrorPage />,
        children: [
            {
                errorElement: <ErrorPage />,
                children: [
                    { path: '/', element: <MainContent/>},
                    { path: '/CadastroPessoa', element: <CadastroPessoa /> },
                    { path: '/ListagemPessoa', element: <ListagemPessoa /> },
                    { path: '/CadastroCategoria', element: <CadastroCategoria /> },
                    { path: '/ListagemCategoria', element: <ListagemCategoria /> },
                    { path: '/CadastroTransacao', element: <CadastroTransacao /> },
                    { path: '*', element: <ErrorPage /> },
                ]
            }
        ]
    },
]);

export default router;