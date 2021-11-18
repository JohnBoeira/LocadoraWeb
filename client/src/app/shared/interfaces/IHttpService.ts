import { Observable } from "rxjs";
import { EntityViewModel } from "../viewModels/entityViewModel";


export interface IHttpService <EntityListViewModel, EntityCreateViewModel extends EntityViewModel, EntityDetailsViewModel extends EntityViewModel, EntityEditViewModel extends EntityViewModel> {

    obterEntidades(): Observable<EntityListViewModel[]>

    adicionarEntidade(entidade: EntityCreateViewModel): Observable<EntityCreateViewModel>

    obterEntidadePorId(entidadeId: number): Observable<EntityDetailsViewModel>

    editarEntidade(entidade: EntityEditViewModel): Observable<EntityEditViewModel>

    excluirEntidade(entidadeId: number): Observable<number>
}