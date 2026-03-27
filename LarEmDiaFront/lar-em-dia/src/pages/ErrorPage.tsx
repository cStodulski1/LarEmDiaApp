// pages/ErrorPage.tsx
import { Button, Result } from 'antd';
import { useNavigate, useRouteError, isRouteErrorResponse } from 'react-router-dom';

const ErrorPage: React.FC = () => {
    const navigate = useNavigate();
    const error = useRouteError();

    const getErrorInfo = () => {
        if (isRouteErrorResponse(error)) {
            return {
                status: String(error.status) as '403' | '404' | '500',
                title: error.statusText,
                subtitle: error.data?.message ?? 'Ocorreu um erro inesperado.',
            };
        }

        if (error instanceof Error) {
            return {
                status: '500' as const,
                title: error.name,
                subtitle: error.message,
            };
        }

        return {
            status: '500' as const,
            title: 'Algo deu errado',
            subtitle: 'Ocorreu um erro inesperado. Tente novamente mais tarde.',
        };
    };

    const { status, title, subtitle } = getErrorInfo();

    return (
        <Result
            status={status}
            title={title}
            subTitle={subtitle}
            extra={
                <Button type="primary" onClick={() => navigate('/')}>
                    Voltar ao início
                </Button>
            }
        />
    );
};

export default ErrorPage;