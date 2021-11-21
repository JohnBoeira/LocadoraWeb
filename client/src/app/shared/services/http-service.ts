import { environment } from "src/environments/environment";
import { EntityViewModel } from "../viewModels/entityViewModel";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { IHttpService } from "../interfaces/IHttpService";

export class HttpService<EntityListViewModel, EntityCreateViewModel extends EntityViewModel, EntityDetailsViewModel extends EntityViewModel, EntityEditViewModel extends EntityViewModel> implements IHttpService<EntityListViewModel, EntityCreateViewModel, EntityDetailsViewModel, EntityEditViewModel>
{
    
    constructor(private http: HttpClient, private nomeDaEntidade : string) {
      
    }
   

    private apiUrl = environment.urlBase + this.nomeDaEntidade;

    public obterEntidades(): Observable<EntityListViewModel[]> {
        return this.http.get<EntityListViewModel[]>(`${this.apiUrl}`);
    }

    public adicionarEntidade(entidade: EntityCreateViewModel): Observable<EntityCreateViewModel> {
        return this.http.post<EntityCreateViewModel>(this.apiUrl, entidade);
    }

    public obterEntidadePorId(entidadeId: number): Observable<EntityDetailsViewModel> {
        return this.http.get<EntityDetailsViewModel>(`${this.apiUrl}/${entidadeId}`);
    }

    public editarEntidade(entidade: EntityEditViewModel): Observable<EntityEditViewModel> {
        return this.http.put<EntityEditViewModel>(`${this.apiUrl}/${entidade.id}`, entidade);
    }

    public excluirEntidade(entidadeId: number): Observable<number> {
        return this.http.delete<number>(`${this.apiUrl}/${entidadeId}`);
    }

}