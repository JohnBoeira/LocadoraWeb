import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IHttpClienteService } from 'src/app/shared/interfaces/IHttpsClienteService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { ClienteListViewModel } from 'src/app/shared/viewModels/Cliente/ClienteListViewModel';

@Component({
  selector: 'app-cliente-listar',
  templateUrl: './cliente-listar.component.html',
})
export class ClienteListarComponent implements OnInit {

  listaClientesTotal: ClienteListViewModel[];
  listaClientes: ClienteListViewModel[];
  clienteSelecionado: any;

  page = 1;
  pageSize = 5;
  collectionSize = 0;

  constructor(private router: Router, @Inject('IHttpClienteServiceToken') private servicoCliente: IHttpClienteService, private servicoModal: NgbModal, private toastService: ToastService) {
  }

  ngOnInit(): void {
    this.obterClientes();
  }

  obterClientes(): void {
    this.servicoCliente.obterEntidades()
      .subscribe(Clientes => {
        this.listaClientesTotal = Clientes;
        this.atualizarClientes();
      });
  }

  formatarData(data: Date): string {
    return new Date(data).toLocaleDateString();
  }

  atualizarClientes() {
    this.listaClientes = this.listaClientesTotal
      .map((Cliente, i) => ({ u: i + 1, ...Cliente }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);

    this.collectionSize = this.listaClientesTotal.length;
  }

  abrirConfirmacao(modal: any) {
    this.servicoModal.open(modal).result.then((resultado) => {
      if (resultado == 'Excluir') {
        this.servicoCliente.excluirEntidade(this.clienteSelecionado)
        .subscribe(
          () => {
            this.toastService.show('Cliente removido com sucesso!',
              { classname: 'bg-success text-light', delay: 4000 });

            setTimeout(() => {
              this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
                this.router.navigate(['cliente/listar']);
              });
            }, 2000);
          },
          erro => {
            this.toastService.show('Erro ao remover cliente: ' + erro.error.errors["Nome"].toString(),
              { classname: 'bg-danger text-light', delay: 5000 });
          }
        );
      }
    }).catch(erro => erro);
  }

}
