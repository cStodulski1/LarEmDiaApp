import { Button, Form, Input, InputNumber } from 'antd';
import type { PessoaDto } from '../../models/PessoaDto';
import { cadastrarPessoa } from '../../services/PessoaService';
import { toast } from 'sonner';

export const FormCadastroPessoas: React.FC = () => {
  const [form] = Form.useForm();

  const onFinish = async (values: {nome: string; idade: number}) => {
      
      let pessoaDto: PessoaDto = {
          nome: values.nome,
          idade: values.idade
      };
      
      try {
        const response = await cadastrarPessoa(pessoaDto);
        toast.success(response?.data)
        form.resetFields();
      } catch (error) {
        toast.error("Erro ao cadastrar pessoa!")
      }
    };

  return (
    <Form
      form={form}
      onFinish={onFinish}
      layout="vertical"
      style={{ maxWidth: 480 }}
    >
      <Form.Item label="Nome" name="nome"
        rules={[{ required: true, message: 'Nome é obrigatório' }]}
      >
        <Input placeholder="Insira o nome" />
      </Form.Item>
      <Form.Item label="Idade" name="idade"
        rules={[{ required: true, message: 'Idade é obrigatória' }]}
      >
        <InputNumber 
        placeholder="Insira a idade" 
        min={1} max={100} style={{width: '100%'}}
        onKeyDown={(e) => {
            if (e.key === '-' || e.key === '+') {
                e.preventDefault();
            }
        }}/>
      </Form.Item>
      <Form.Item>
        <Button type="primary" htmlType='submit'>Cadastrar</Button>
      </Form.Item>
    </Form>
  );
};

