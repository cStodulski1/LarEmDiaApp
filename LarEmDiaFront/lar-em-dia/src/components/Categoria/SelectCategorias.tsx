import React, { useEffect, useState } from 'react';
import { Select } from 'antd';
import { listarCategorias } from '../../services/CategoriaService';
import type { DefaultOptionType } from 'antd/es/select';

interface SelectCategoriasProps {
    value?: string;
    onChange?: (value: String, option: DefaultOptionType | DefaultOptionType[] | undefined) => void;
    shouldLoad?: boolean;
    finalidade?: string;
}

const SelectCategorias: React.FC<SelectCategoriasProps> = ({
    value,
    onChange,
    shouldLoad,
    finalidade = 'Ambas'
}) => {
    const [options, setOptions] = useState<{ value: string; label: string }[]>([]);
    const [loading, setLoading] = useState(false);
    const [loaded, setLoaded] = useState(false);

    const fetchCategorias = async () => {
        if (loaded) return;
        setLoading(true);
        try {
            const data = await listarCategorias('', finalidade, 1, 10);
            setOptions(data.data.map((c) => ({value: c.categoriaId, label: c.descricao})));
            setLoaded(true);
        } finally {
            setLoading(false);
        }
    };
    useEffect(() => {
        setLoaded(false);
        setOptions([]);
    }, [finalidade])

    return (
        <Select<String>
            value={value}
            onChange={onChange}
            options={options}
            loading={loading}
            disabled={!shouldLoad}
            onFocus={fetchCategorias}
            showSearch = {{optionFilterProp: "label"}}
            placeholder="Selecione uma categoria"
            notFoundContent={loading ? 'Carregando...' : 'Nenhuma categoria encontrada'}
        />
    );
}

export default SelectCategorias;