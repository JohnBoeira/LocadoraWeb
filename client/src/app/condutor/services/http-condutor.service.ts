import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { HttpService } from "src/app/shared/services/http-service";
import { CondutorCreateViewModel } from "src/app/shared/viewModels/condutor/condutorCreateViewModel";
import { CondutorDetailsViewModel } from "src/app/shared/viewModels/condutor/CondutorDetailsViewModel";
import { CondutorEditViewModel } from "src/app/shared/viewModels/condutor/CondutorEditViewModel";
import { CondutorListViewModel } from "src/app/shared/viewModels/condutor/CondutorListViewModel";
import { CondutorListarComponent } from "../listar/condutor-listar.component";

@Injectable({
    providedIn: 'root'
})
export class HttpCondutorService extends HttpService<CondutorListViewModel,CondutorCreateViewModel,CondutorDetailsViewModel, CondutorEditViewModel> {
    constructor(http: HttpClient){
        super(http,"condutor");
    }
}