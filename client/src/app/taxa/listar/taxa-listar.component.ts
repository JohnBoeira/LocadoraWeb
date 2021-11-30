import { Component, Inject, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { IHttpTaxaService } from "src/app/shared/interfaces/IHttpTaxaSerivce";
import { ToastService } from "src/app/shared/services/toast.service";

@Component({
    selector: 'app-listarTaxa',
    templateUrl: './Taxa-listar.component.html'
  })
  export class TaxaListarComponent implements OnInit {
  
    listaTaxasTotal: TaxaListViewModel[];
    listaTaxas: TaxaListViewModel[];
    TaxaSelecionado: any;
  
    page = 1;
    pageSize = 5;
    collectionSize = 0;
  
    constructor(private router: Router, @Inject('IHttpTaxaServiceToken') private servicoTaxa: IHttpTaxaService, private servicoModal: NgbModal,   private toastService: ToastService) {
    }
  
    ngOnInit(): void {
      this.obterTaxas();
    }
  
    obterTaxas(): void {
      this.servicoTaxa.obterEntidades()
        .subscribe(Taxas => {
          this.listaTaxasTotal = Taxas;
          this.atualizarTaxas();
        });
    }
  
    atualizarTaxas() {
      this.listaTaxas = this.listaTaxasTotal
        .map((Taxa, i) => ({ u: i + 1, ...Taxa }))
        .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  
      this.collectionSize = this.listaTaxasTotal.length;
    }
  
    abrirConfirmacao(modal: any) {
      this.servicoModal.open(modal).result.then((resultado) => {
        if (resultado == 'Excluir') {
          this.servicoTaxa.excluirEntidade(this.TaxaSelecionado)
          .subscribe(
            () => {
              this.toastService.show('Taxa removido com sucesso!',
                { classname: 'bg-success text-light', delay: 5000 });
  
              setTimeout(() => {
                this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
                  this.router.navigate(['Taxa/listar']);
                });
              }, 5000);
            },
            erro => {
              this.toastService.show('Erro ao remover Taxa: ' + erro.error.errors["Nome"].toString(),
                { classname: 'bg-danger text-light', delay: 5000 });
            }
          );
        }
      }).catch(erro => erro);
    }
  }
  