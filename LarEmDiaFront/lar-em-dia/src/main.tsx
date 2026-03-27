import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import './App.css'
import router from './components/RouterProvider.tsx'
import { Toaster } from 'sonner'
import { RouterProvider } from 'react-router-dom'
import ErrorBoundary from 'antd/es/alert/ErrorBoundary'
import { ConfigProvider } from 'antd'
import ptBR from 'antd/es/locale/pt_BR';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ConfigProvider locale={ptBR}>
      <ErrorBoundary>
        <Toaster richColors position="top-right" />
        <RouterProvider router={router} />
      </ErrorBoundary>
    </ConfigProvider>
  </StrictMode>,
)
