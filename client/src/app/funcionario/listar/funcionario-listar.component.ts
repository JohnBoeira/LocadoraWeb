import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { FuncionarioListViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioListViewModel';

@Component({
  selector: 'app-funcionario-listar',
  templateUrl: './funcionario-listar.component.html',

})
export class FuncionarioListarComponent implements OnInit {

  listaFuncionariosTotal: FuncionarioListViewModel[];
  listaFuncionarios: FuncionarioListViewModel[];
  funcionarioSelecionado: any;

  page = 1;
  pageSize = 5;
  collectionSize = 0;

  constructor(private router: Router, @Inject('IHttpFuncionarioServiceToken') private servicoFuncionario: IHttpFuncionarioService, private servicoModal: NgbModal, private toastService: ToastService) {
  }

  ngOnInit(): void {
    this.obterFuncionarios();
  }

  obterFuncionarios(): void {
    this.servicoFuncionario.obterEntidades()
      .subscribe(Funcionarios => {
        this.listaFuncionariosTotal = Funcionarios;
        this.atualizarFuncionarios();
      });
  }

  formatarData(data: Date): string {
    return new Date(data).toLocaleDateString();
  }

  atualizarFuncionarios() {
    this.listaFuncionarios = this.listaFuncionariosTotal
      .map((Funcionario, i) => ({ u: i + 1, ...Funcionario }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);

    this.collectionSize = this.listaFuncionariosTotal.length;
  }

  abrirConfirmacao(modal: any) {
    this.servicoModal.open(modal).result.then((resultado) => {
      if (resultado == 'Excluir') {
        this.servicoFuncionario.excluirEntidade(this.funcionarioSelecionado)
          .subscribe(
            () => {
              this.toastService.show('Funcionário removido com sucesso!',
                { classname: 'bg-success text-light', delay: 4000 });
  
              setTimeout(() => {
                this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
                  this.router.navigate(['funcionario/listar']);
                });
              }, 2000);
            },
            erro => {
              this.toastService.show('Erro ao remover funcionario: ' + erro.error.errors["Nome"].toString(),
                { classname: 'bg-danger text-light', delay: 5000 });
            }
          );
      }
    }).catch(erro => erro);
  }

}
