import { Component, Inject, OnInit } from "@angular/core";
import { inject } from "@angular/core/testing";
import { Router } from "@angular/router";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { IHttpService } from "../interfaces/IHttpService";
import { EntityViewModel } from "../viewModels/entityViewModel";

@Component({
  template: ''
})

export class ListarComponentBase <EListViewModel, ECreateViewModel extends EntityViewModel, EDetailsViewModel extends EntityViewModel, EEitViewModel extends EntityViewModel> implements OnInit {

   listaEntidadesTotal: EListViewModel[];
   listaEntidades: EListViewModel[];
   Entidadeselecionado: any;
 
   page = 1;
   pageSize = 5;
   collectionSize = 0;
 
   constructor(private router: Router, @Inject('') private servicoEntidade: IHttpService<EListViewModel, ECreateViewModel, EDetailsViewModel, EEitViewModel>, private servicoModal: NgbModal, @Inject('') private nomeDaEntidade : string) {
    
  
  }
 
   ngOnInit(): void {
     this.obterEntidades();
   }
 
   obterEntidades(): void {
     this.servicoEntidade.obterEntidades()
       .subscribe(Entidades => {
         this.listaEntidadesTotal = Entidades;
         this.atualizarEntidades();
       });
   }
 
   atualizarEntidades() {
     this.listaEntidades = this.listaEntidadesTotal
       .map((Entidade, i) => ({ u: i + 1, ...Entidade }))
       .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
 
     this.collectionSize = this.listaEntidadesTotal.length;
   }
 
   abrirConfirmacao(modal: any) {
     this.servicoModal.open(modal).result.then((resultado) => {
       if (resultado == 'Excluir') {
         this.servicoEntidade.excluirEntidade(this.Entidadeselecionado)
           .subscribe(() => {
             this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
               this.router.navigate([this.nomeDaEntidade +'/listar']);
             });
           });
       }
     }).catch(erro => erro);
   }
 
 }