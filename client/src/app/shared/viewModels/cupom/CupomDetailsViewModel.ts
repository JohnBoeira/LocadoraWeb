import { EntityViewModel } from "../entityViewModel";

export class CupomDetailsViewModel extends EntityViewModel{
    nome: string;
    valor: number;
    dataValidade: Date;
    valorMinimo: number;
    tipo: number;
}