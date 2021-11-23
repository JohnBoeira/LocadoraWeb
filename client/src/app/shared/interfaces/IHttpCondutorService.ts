import { CondutorCreateViewModel } from "../viewModels/condutor/condutorCreateViewModel";
import { CondutorDetailsViewModel } from "../viewModels/condutor/CondutorDetailsViewModel";
import { CondutorEditViewModel } from "../viewModels/condutor/CondutorEditViewModel";
import { CondutorListViewModel } from "../viewModels/condutor/CondutorListViewModel";
import { IHttpService } from "./IHttpService";

export interface IHttpCondutorService extends IHttpService<CondutorListViewModel,CondutorCreateViewModel,CondutorDetailsViewModel, CondutorEditViewModel>{
    
}