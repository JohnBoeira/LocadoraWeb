import { Observable } from "rxjs";
import { CupomCreateViewModel } from "../viewModels/cupom/CupomCreateViewModel";
import { CupomDetailsViewModel } from "../viewModels/cupom/CupomDetailsViewModel";
import { CupomEditViewModel } from "../viewModels/cupom/CupomEditViewModel";
import { CupomListViewModel } from "../viewModels/cupom/CupomListViewModel";
import { IHttpService } from "./IHttpService";

export interface IHttpCupomService extends IHttpService<CupomListViewModel, CupomCreateViewModel, CupomDetailsViewModel, CupomEditViewModel> {

   
}