export interface PessoaTotaisDto {
  id: string;
  nome: string;
  idade: number;
  ehMaiorDeIdade: boolean;
  valorReceita: number;
  valorDespesa: number;
  saldo: number;
}

export interface TotaisDto {
    totalDeReceita: number;
    totalDeDespesas: number;
    saldoLiquido: number;
}