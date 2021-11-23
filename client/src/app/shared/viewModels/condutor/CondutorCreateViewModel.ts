import { EntityViewModel } from "../entityViewModel";

export class CondutorCreateViewModel extends EntityViewModel{
    nome : string;
    endereco: string;
    telefone: string;
    rg : string;
    cpf : string;
    cnh : string;
    dataValidadeCnh : Date;
    clienteId : number;
}