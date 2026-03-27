import React, { useEffect, useState } from 'react';
import { Select } from 'antd';
import type { DefaultOptionType } from 'antd/es/select';
import { listarPessoas } from '../../services/PessoaService';
import type { Pessoa } from '../../models/PessoaDto';

interface SelectPessoasProps {
    value?: string;
    onChange?: (value: String, option: DefaultOptionType | DefaultOptionType[] | undefined) => void;
    onDataLoaded?: (pessoas: Pessoa[]) => void;
}

const SelectPessoas: React.FC<SelectPessoasProps> = ({
    value,
    onChange,
    onDataLoaded
}) => {
    const [options, setOptions] = useState<{ value: string; label: string }[]>([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        const fetchPessoas = async () => {
            setLoading(true);
            try {
                const data = await listarPessoas('', 1, 10);
                const sorted = data.data.sort((a, b) => b.idade - a.idade);
                setOptions(sorted.map((p) => ({ value: p.id, label: `${p.nome}, ${p.idade}`})));
                onDataLoaded?.(sorted);
            } finally {
                setLoading(false);
            }
        };
        fetchPessoas();
    }, []);

    return (
        <Select<String>
            value={value}
            onChange={onChange}
            options={options}
            loading={loading}
            showSearch = {{optionFilterProp: "label"}}
            placeholder="Selecione uma pessoa"
            notFoundContent={loading ? 'Carregando...' : 'Nenhuma pessoa encontrada'}
        />
    );
}

export default SelectPessoas;