import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { HttpService } from "src/app/shared/http-service";
import { IHttpClienteService } from "src/app/shared/interfaces/IHttpsClienteService";
import { ClienteCreateViewModel } from "src/app/shared/viewModels/Cliente/ClienteCreateViewModel";
import { ClienteDetailsViewModel } from "src/app/shared/viewModels/Cliente/ClienteDetails";
import { ClienteEditViewModel } from "src/app/shared/viewModels/Cliente/ClienteEditViewModel";
import { ClienteListViewModel } from "src/app/shared/viewModels/Cliente/ClienteListViewModel";

@Injectable({
   providedIn: 'root'
 })
 export class HttpClienteService extends HttpService<ClienteListViewModel, ClienteCreateViewModel, ClienteDetailsViewModel, ClienteEditViewModel> implements IHttpClienteService {
   constructor(http: HttpClient) {
     super(http, "cliente");
   }
 
 }