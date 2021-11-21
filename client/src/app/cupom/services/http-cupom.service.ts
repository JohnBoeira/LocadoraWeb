import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/shared/services/http-service';
import { IHttpCupomService } from 'src/app/shared/interfaces/IHttpCupomService';
import { CupomCreateViewModel } from 'src/app/shared/viewModels/cupom/CupomCreateViewModel';
import { CupomDetailsViewModel } from 'src/app/shared/viewModels/cupom/CupomDetailsViewModel';
import { CupomEditViewModel } from 'src/app/shared/viewModels/cupom/CupomEditViewModel';
import { CupomListViewModel } from 'src/app/shared/viewModels/cupom/CupomListViewModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpCupomService extends HttpService<CupomListViewModel,CupomCreateViewModel, CupomDetailsViewModel, CupomEditViewModel> implements IHttpCupomService {
  constructor(http: HttpClient){
    super(http,"cupom");
}

}
