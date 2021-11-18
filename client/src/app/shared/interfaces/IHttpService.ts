import { Observable } from "rxjs";
import { EntityViewModel } from "../viewModels/entityViewModel";


export interface IHttpService <EntityListViewModel, EntityCreateViewModel extends EntityViewModel, EntityDetailsViewModel extends EntityViewModel, EntityEditViewModel extends EntityViewModel> {

    obterRegistros(): Observable<EntityListViewModel[]>

    adicionarParceiro(entidade: EntityCreateViewModel): Observable<EntityCreateViewModel>

    obterParceiroPorId(entidadeId: number): Observable<EntityDetailsViewModel>

    editarParceiro(entidade: EntityEditViewModel): Observable<EntityEditViewModel>

    excluirParceiro(entidadeId: number): Observable<number>
}