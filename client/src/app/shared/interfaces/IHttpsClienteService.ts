import { ClienteCreateViewModel } from "../viewModels/Cliente/ClienteCreateViewModel";
import { ClienteDetailsViewModel } from "../viewModels/Cliente/ClienteDetails";
import { ClienteEditViewModel } from "../viewModels/Cliente/ClienteEditViewModel";
import { ClienteListViewModel } from "../viewModels/Cliente/ClienteListViewModel";
import { IHttpService } from "./IHttpService";

export interface IHttpClienteService extends IHttpService<ClienteListViewModel,ClienteCreateViewModel,ClienteDetailsViewModel, ClienteEditViewModel> {

    
}