
import { EntityViewModel } from "../entityViewModel";

export class ClienteCreateViewModel extends EntityViewModel{
   nome: string;
   endereco: string;
   telefone: string;
   cnpj : string;
   rg: string;
   cpf: string;
   tipoPessoa: number;
   email: string;
}