export type TransacaoDto = {
    descricao: string;
    valor: number;
    finalidade: string;
    categoriaId: string;
    pessoaId: string;
}

export interface Transacao {
    id: string;
    descricao: string;
    finalidade: string;
}