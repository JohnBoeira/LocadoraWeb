import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { HttpService } from "src/app/shared/http-service";
import { FuncionarioCreateViewModel } from "src/app/shared/viewModels/funcionario/FuncionarioCreateViewModel";
import { FuncionarioDetailsViewModel } from "src/app/shared/viewModels/funcionario/FuncionarioDetailsViewModel";
import { FuncionarioEditViewModel } from "src/app/shared/viewModels/funcionario/FuncionarioEditViewModel";
import { FuncionarioListViewModel } from "src/app/shared/viewModels/funcionario/FuncionarioListViewModel";
import { ParceiroListViewModel } from "src/app/shared/viewModels/parceiro/ParceiroListViewModel";

@Injectable({
   providedIn: 'root'
})
export class HttpFuncionarioService extends HttpService<FuncionarioListViewModel,FuncionarioCreateViewModel,FuncionarioDetailsViewModel, FuncionarioEditViewModel> {
   constructor(http: HttpClient){
       super(http,"funcionario");
   }
}