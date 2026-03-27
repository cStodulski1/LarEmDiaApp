import axios from 'axios';
import type { Categoria, CategoriaDto } from '../models/Categoria';
import type { PagedResult } from '../models/PagedResult';

const API_URL = "https://localhost:7294/api/Categorias";

export const cadastrarCategoria = async (categoriaDto: CategoriaDto) => {
    try {
        const response = await axios.post<string>(API_URL + '/Cadastrar', categoriaDto);
        return response;
    } catch (error) {
        console.log(error)
        //adicionar handler
    }
}

export const listarCategorias = async (busca: string, finalidade: string = 'Ambas', pageNumber = 1, pageSize = 10) => {
  const response = await axios.get<PagedResult<Categoria>>(API_URL + '/Listar', {
    params: { busca, finalidade, pageNumber, pageSize },
  });  
  return response.data;
};