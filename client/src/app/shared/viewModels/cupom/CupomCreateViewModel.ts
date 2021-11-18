import { EntityViewModel } from "../entityViewModel";

export class CupomCreateViewModel extends EntityViewModel {
    nome: string;
    valor: number;
    datavalidade: Date;
    valorMinimo: number;
    tipo: number;
}