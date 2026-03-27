import axios from 'axios';
import type { TransacaoDto } from '../models/Transacao';

const API_URL = "https://localhost:7294/api/Transacao";

export const cadastrarTransacao = async (transacaoDto: TransacaoDto) => {
    try {
        const response = await axios.post<string>(API_URL + '/Cadastrar', transacaoDto);
        return response.data;
    } catch (error) {
        console.log(error)
        //adicionar handler
    }
}