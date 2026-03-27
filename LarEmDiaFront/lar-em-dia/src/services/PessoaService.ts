import axios from 'axios';
import type { Pessoa, PessoaDto } from '../models/PessoaDto';
import type { PagedResult } from '../models/PagedResult';

const API_URL = "https://localhost:7294/api/Pessoas";

export const cadastrarPessoa = async (pessoaDto: PessoaDto) => {
    try {
        const response = await axios.post<string>(API_URL + '/Cadastrar', pessoaDto);
        return response;
    } catch (error) {
        console.log(error)
        //adicionar handler
    }
}

export const listarPessoas = async (busca: string, pageNumber = 1, pageSize = 10) => {
    const response = await axios.get<PagedResult<Pessoa>>(API_URL + '/Listar',{
        params: { busca, pageNumber, pageSize },
    });
    return response.data;
}

export const excluirPessoa = async (id: string) => {
    const response = await axios.delete<string>(API_URL + `/Excluir/${id}`);
    return response;
}

export const editarPessoa = async (id: string, pessoa: PessoaDto) => {
    const response = await axios.patch<string>(API_URL + `/Atualizar/${id}`, pessoa);
    return response;
}