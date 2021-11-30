import { HttpService } from "src/app/shared/services/http-service";

export class HttpTaxaService extends HttpService<ParceiroListViewModel,ParceiroCreateViewModel,ParceiroDetailsViewModel, ParceiroEditViewModel> {
    constructor(http: HttpClient){
        super(http,"parceiro");
    }
}