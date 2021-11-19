import { FuncionarioCreateViewModel } from "../viewModels/funcionario/FuncionarioCreateViewModel";
import { FuncionarioDetailsViewModel } from "../viewModels/funcionario/FuncionarioDetailsViewModel";
import { FuncionarioEditViewModel } from "../viewModels/funcionario/FuncionarioEditViewModel";
import { FuncionarioListViewModel } from "../viewModels/funcionario/FuncionarioListViewModel";
import { IHttpService } from "./IHttpService";

export interface IHttpFuncionarioService extends IHttpService<FuncionarioListViewModel,FuncionarioCreateViewModel,FuncionarioDetailsViewModel, FuncionarioEditViewModel> {

   
}