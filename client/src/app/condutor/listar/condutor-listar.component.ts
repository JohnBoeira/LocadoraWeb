import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IHttpCondutorService } from 'src/app/shared/interfaces/IHttpCondutorService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { CondutorListViewModel } from 'src/app/shared/viewModels/condutor/CondutorListViewModel';

@Component({
  selector: 'app-condutor-listar',
  templateUrl: 'condutor-listar.component.html',

})
export class CondutorListarComponent implements OnInit {

  listaCondutor: CondutorListViewModel[];
  listaCondutorTotal: CondutorListViewModel[];
  condutorSelecionado: any;

  page = 1;
  pageSize = 5;
  collectionSize = 0;

  constructor(private router: Router, @Inject('IHttpCondutorServiceToken') private servicocondutor: IHttpCondutorService, private servicoModal: NgbModal, private toastService : ToastService) { }

  ngOnInit(): void {
    this.obterCondutor();
  }

  obterCondutor(): void {
    this.servicocondutor.obterEntidades()
      .subscribe(Condutor => {
        this.listaCondutorTotal = Condutor;
        this.atualizarCondutor();
      });
  }

  atualizarCondutor() {
    this.listaCondutor = this.listaCondutorTotal
      .map((condutor, i) => ({ u: i + 1, ...condutor }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);

    this.collectionSize = this.listaCondutorTotal.length;
  }

  formatarData(data: Date): string {
    return new Date(data).toLocaleDateString();
  }

  abrirConfirmacao(modal: any) {
    this.servicoModal.open(modal).result.then((resultado) => {
      if (resultado == 'Excluir') {
        this.servicocondutor.excluirEntidade(this.condutorSelecionado)
        .subscribe(
          () => {
            this.toastService.show('condutor removido com sucesso!',
              { classname: 'bg-success text-light', delay: 4000 });

            setTimeout(() => {
              this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
                this.router.navigate(['condutor/listar']);
              });
            }, 2000);
          },
          erro => {
            this.toastService.show('Erro ao remover condutor: ' + erro.error.errors["Nome"].toString(),
              { classname: 'bg-danger text-light', delay: 5000 });
          }
        );
      }
    }).catch(erro => erro);
  }

}
