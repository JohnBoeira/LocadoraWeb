import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IHttpClienteService } from 'src/app/shared/interfaces/IHttpsClienteService';
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

  constructor(private router: Router, @Inject('IHttpClienteServiceToken') private servicoCliente: IHttpClienteService, private servicoModal: NgbModal) {
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
          .subscribe(() => {
            this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
              this.router.navigate(['cliente/listar']);
            });
          });
      }
    }).catch(erro => erro);
  }

}
