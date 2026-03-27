import React, { useEffect } from 'react';
import { Button, Form, Input, InputNumber, Modal } from 'antd';
import type { Pessoa, PessoaDto } from '../../models/PessoaDto';
import { editarPessoa } from '../../services/PessoaService';
import { toast } from 'sonner';

interface EditarPessoaModalProps {
  pessoa: Pessoa | null;
  open: boolean;
  onClose: () => void;
  onSave: (id: string, pessoaDto: PessoaDto) => void;
}

export const EditarPessoaModal: React.FC<EditarPessoaModalProps> = ({
  pessoa,
  open,
  onClose,
  onSave,
}) => {
  const [form] = Form.useForm();

  useEffect(() => {
    if (pessoa) {
      form.setFieldsValue({ nome: pessoa.nome, idade: pessoa.idade });
    }
  }, [pessoa, form]);

  const onFinish = async (values: { nome: string; idade: number }) => {
    const pessoaDto: PessoaDto = {
      nome: values.nome,
      idade: values.idade,
    };

    try {
      const response = await editarPessoa(pessoa!.id, pessoaDto);
      toast.success(response?.data);
      form.resetFields();
      onSave(pessoa!.id, pessoaDto);
      onClose();
    } catch (error) {
      toast.error('Erro ao editar pessoa!');
    }
  };

  const handleCancel = () => {
    form.resetFields();
    onClose();
  };

  return (
    <Modal
      title="Editar Pessoa"
      open={open}
      onCancel={handleCancel}
      footer={null}
    >
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
            min={1} max={100} style={{ width: '100%' }}
            onKeyDown={(e) => {
              if (e.key === '-' || e.key === '+') {
                e.preventDefault();
              }
            }}
          />
        </Form.Item>
        <Form.Item>
          <Button type="primary" htmlType="submit">Salvar</Button>
        </Form.Item>
      </Form>
    </Modal>
  );
};