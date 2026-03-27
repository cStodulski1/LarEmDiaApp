import React from 'react';
import { Radio } from 'antd';

interface FinalidadeRadioProps {
  value?: string;
  onChange?: (value: string) => void;
}
const FinalidadeRadio: React.FC<FinalidadeRadioProps> = ({value, onChange}) => {
  
  return (
    <>
    <Radio.Group
        value={value}
        onChange={(e) => onChange?.(e.target.value)}
    >
        <Radio value="Despesa">
            Despesa
        </Radio>
        <Radio value="Receita">
            Receita
        </Radio>
    </Radio.Group>

    </>
  );
};

export default FinalidadeRadio;