
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/shared/http-service';
import { IHttpParceiroService } from 'src/app/shared/interfaces/IHttpParceiroService';
import { ParceiroCreateViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroCreateViewModel';
import { ParceiroDetailsViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroDetailsViewModel';
import { ParceiroEditViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroEditViewModel';
import { ParceiroListViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroListViewModel';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HttpParceiroService extends HttpService<ParceiroListViewModel,ParceiroCreateViewModel,ParceiroDetailsViewModel, ParceiroEditViewModel> {
    constructor(http: HttpClient){
        super(http,"parceiro");
    }
}