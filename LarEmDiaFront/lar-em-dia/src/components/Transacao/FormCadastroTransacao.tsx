import { Button, Form, Input } from 'antd';
import type { TransacaoDto } from '../../models/Transacao';
import FinalidadeRadio from '../FinalidadeRadio';
import SelectCategorias from '../Categoria/SelectCategorias';
import SelectPessoas from '../Pessoa/SelectPessoas';
import type { Pessoa } from '../../models/PessoaDto';
import { useRef } from 'react';
import { cadastrarTransacao } from '../../services/TransacaoService';
import InputValorBRL from '../InputValorBRL';
import { toast } from 'sonner';

const { TextArea } = Input;

export const FormCadastroTransacao: React.FC = () => {
  const [form] = Form.useForm();
  const pessoasRef = useRef<Pessoa[]>([]);
  const finalidade = Form.useWatch('finalidade', form);

  const onFinish = async (values: {
    descricao: string; 
    valor: number;
    finalidade: string;
    categoriaId: string;
    pessoaId: string;
}) => {
      
      let transacaoDto: TransacaoDto = {
          descricao: values.descricao,
          valor: values.valor,
          finalidade: values.finalidade,
          categoriaId: values.categoriaId,
          pessoaId: values.pessoaId
      };

      try {
        const response = await cadastrarTransacao(transacaoDto);
        toast.success(response)
        form.resetFields();
      } catch (error) {
        toast.error("Erro ao cadastrar transação!");
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
         placeholder="Insira uma descrição para transação" 
         />
      </Form.Item>
      <InputValorBRL
        name="valor" label="Valor" required
      />
      <Form.Item label="Pessoa" name="pessoaId" required>
        <SelectPessoas onDataLoaded={(data) => (pessoasRef.current = data)}/>
      </Form.Item>
      <Form.Item 
        label="Finalidade" 
        name="finalidade"
        rules={[
        {
            required: true,
            validator: async (_, value) => {
                const pessoaId = form.getFieldValue('pessoaId');
                const pessoa = pessoasRef.current.find((p) => p.id === pessoaId);

                if (value === 'Receita' && pessoa && pessoa.idade < 18) {
                    return Promise.reject('Pessoa menor de 18 anos não pode cadastrar transação do tipo Receita');
                }
                return Promise.resolve();
            }
        }
    ]}>
        <FinalidadeRadio/>
      </Form.Item>
      <Form.Item label="Categoria" name="categoriaId" required>
        <SelectCategorias
            shouldLoad={finalidade !== null}
            finalidade={finalidade ?? 'Ambas'}
        />
        </Form.Item>
      <Form.Item>
        <Button type="primary" htmlType='submit'>Cadastrar</Button>
      </Form.Item>
    </Form>
  );
};

