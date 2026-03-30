import axios from 'axios';
import type { PagedResult } from '../models/PagedResult';
import { type TotaisDto, type PessoaTotaisDto } from '../models/PessoaTotaisDto';


const API_URL = "https://localhost:7294/api/Relatorio";



export const listarPessoasTotais = async (pageNumber = 1, pageSize = 10) => {
    const response = await axios.get<PagedResult<PessoaTotaisDto>>(API_URL + '/ListaPessoasTotais',{
        params: {pageNumber, pageSize },
    });
    return response.data;
}

export const listarTotais = async () => {
    const response = await axios.get<TotaisDto>(API_URL + '/PessoasTotalSumario');
    return response.data;
}