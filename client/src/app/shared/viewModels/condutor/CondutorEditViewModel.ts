
import { EntityViewModel } from "../entityViewModel";

export class CondutorEditViewModel extends EntityViewModel{
    nome : string;
    endereco: string;
    telefone: string;
    rg : string;
    cpf : string;
    cnh : string;
    dataValidadeCnh : Date;
    clienteId : number;
}