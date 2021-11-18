import { EntityViewModel } from "../entityViewModel";

export class CupomEditViewModel extends EntityViewModel {
    nome: string;
    valor: number;
    datavalidade: Date;
    valorMinimo: number;
    tipo: number;
}