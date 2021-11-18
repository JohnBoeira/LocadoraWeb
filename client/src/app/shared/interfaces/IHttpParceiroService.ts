import { Observable } from "rxjs";
import { ParceiroCreateViewModel } from "../viewModels/parceiro/ParceiroCreateViewModel";
import { ParceiroDetailsViewModel } from "../viewModels/parceiro/ParceiroDetailsViewModel";
import { ParceiroEditViewModel } from "../viewModels/parceiro/ParceiroEditViewModel";
import { ParceiroListViewModel } from "../viewModels/parceiro/ParceiroListViewModel";
import { IHttpService } from "./IHttpService";

export interface IHttpParceiroService extends IHttpService<ParceiroListViewModel,ParceiroCreateViewModel,ParceiroDetailsViewModel, ParceiroEditViewModel> {

    
}