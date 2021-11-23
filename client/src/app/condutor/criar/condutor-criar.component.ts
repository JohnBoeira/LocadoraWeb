import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDateStruct, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IHttpCondutorService } from 'src/app/shared/interfaces/IHttpCondutorService';
import { IHttpClienteService } from 'src/app/shared/interfaces/IHttpsClienteService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { ClienteListViewModel } from 'src/app/shared/viewModels/Cliente/ClienteListViewModel';
import { CondutorCreateViewModel } from 'src/app/shared/viewModels/condutor/condutorCreateViewModel';
import { CondutorListViewModel } from 'src/app/shared/viewModels/condutor/CondutorListViewModel';

@Component({
  selector: 'app-condutor-criar',
  templateUrl: './condutor-criar.component.html',

})
export class CondutorCriarComponent implements OnInit {
  cadastroForm: FormGroup;
  dataValidadeCNH: NgbDateStruct;

  condutor: CondutorCreateViewModel;
  listaClientes: ClienteListViewModel[];


  constructor(@Inject('IHttpCondutorServiceToken') private servicocondutor: IHttpCondutorService,
    @Inject('IHttpClienteServiceToken') private servicoCliente: IHttpClienteService,
    private router: Router, private toastService: ToastService) { }

  ngOnInit(): void {
  

    this.cadastroForm = new FormGroup({
      nome: new FormControl(''),
      endereco: new FormControl(''),
      telefone: new FormControl(''),
      rg: new FormControl(''),
      cpf: new FormControl(''),
      cnh: new FormControl(''),
       dataValidadeCNH: new FormControl(''),
      clienteId: new FormControl(''),
      
    });

    this.carregarClientes();
  }

  adicionarcondutor() {
    this.condutor = Object.assign({}, this.condutor, this.cadastroForm.value);

    this.servicocondutor.adicionarEntidade(this.condutor)
      .subscribe(
        condutor => {
          this.toastService.show('condutor adicionado com sucesso!',
            { classname: 'bg-success text-light', delay: 4000 });
          setTimeout(() => {
            this.router.navigate(['condutor/listar']);
          }, 5000);
        },
        erro => {
          this.toastService.show('Erro ao adicionar condutor: ' + erro.error.errors["Nome"].toString(),
            { classname: 'bg-danger text-light', delay: 4000 });
        }
      );
  }

  carregarClientes(): void {
    this.servicoCliente.obterEntidades()
      .subscribe(Clientes => {
        this.listaClientes = Clientes;
      });
  }

  cancelar(): void {
    this.router.navigate(['condutor/listar']);
  }

 
}
