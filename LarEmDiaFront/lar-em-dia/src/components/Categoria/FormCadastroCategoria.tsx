import { Button, Form, Input } from 'antd';
import type { CategoriaDto } from '../../models/Categoria';
import { cadastrarCategoria } from '../../services/CategoriaService';
import FinalidadeRadio from '../FinalidadeRadio';
import { toast } from 'sonner';

const { TextArea } = Input;

export const FormCadastroCategoria: React.FC = () => {
  const [form] = Form.useForm();

  const onFinish = async (values: {descricao: string; finalidade: string}) => {
      
      let categoriaDto: CategoriaDto = {
          descricao: values.descricao,
          finalidade: values.finalidade
      };
      try {
        const response = await cadastrarCategoria(categoriaDto);
        toast.success(response?.data)
        form.resetFields();
      } catch (error) {
        toast.error("Erro ao cadastrar categoria!");
        console.log(error);
      }
    };

  return (
    <Form
      form={form}
      onFinish={onFinish}
      layout="vertical"
      style={{ maxWidth: 480 }}
      initialValues={{ finalidade: 'Despesa' }}
    >
      <Form.Item label="Descrição" name="descricao"
        rules={[{ required: true, message: 'Descrição é obrigatória' }]}
      >
        <TextArea
         rows={4} 
         maxLength={400} 
         placeholder="Insira uma descrição para categoria" 
         />
      </Form.Item>
      <Form.Item label="Finalidade" name="finalidade">
        <FinalidadeRadio/>
      </Form.Item>
      <Form.Item>
        <Button type="primary" htmlType='submit'>Cadastrar</Button>
      </Form.Item>
    </Form>
  );
};

