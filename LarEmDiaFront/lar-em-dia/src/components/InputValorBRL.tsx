import { Form, Input } from 'antd';

const formatBRL = (raw: string): string => {
    const onlyDigits = raw.replace(/\D/g, '');
    if (!onlyDigits) return '';
    const number = parseInt(onlyDigits, 10) / 100;
    return number.toLocaleString('pt-BR', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2,
    });
};

const parseBRL = (formatted: string): number => {
    const onlyDigits = formatted.replace(/\D/g, '');
    if (!onlyDigits) return 0;
    return parseInt(onlyDigits, 10) / 100;
};

interface InputValorBRLProps {
    label?: string;
    name?: string;
    required?: boolean;
}

const InputValorBRL: React.FC<InputValorBRLProps> = ({
    label = 'Valor',
    name = 'valor',
    required = false,
}) => {
    return (
        <Form.Item
            label={label}
            name={name}
            rules={[{ required, message: `${label} é obrigatório` }]}
            getValueFromEvent={(e) => parseBRL(e.target.value)}
            getValueProps={(value) => ({ value: value ? formatBRL(String(Math.round(value * 100))) : '' })}
        >
            <Input
                prefix="R$"
                placeholder="0,00"
                onChange={(e) => {
                    e.target.value = formatBRL(e.target.value);
                }}
            />
        </Form.Item>
    );
};

export default InputValorBRL;