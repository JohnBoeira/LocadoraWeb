import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IHttpClienteService } from 'src/app/shared/interfaces/IHttpsClienteService';
import { ClienteType } from 'src/app/shared/models/ClienteEnum';
import { ToastService } from 'src/app/shared/services/toast.service';

import { ClienteCreateViewModel } from 'src/app/shared/viewModels/Cliente/ClienteCreateViewModel';

@Component({
  selector: 'app-cliente-criar',
  templateUrl: './cliente-criar.component.html',
})
export class ClienteCriarComponent implements OnInit {

  cadastroForm: FormGroup;
  clienteVM: ClienteCreateViewModel;

  tipos = ClienteType;
  chaves: any[];

  constructor(@Inject('IHttpClienteServiceToken') private servicoCliente: IHttpClienteService, private router: Router, private toastService: ToastService) { }

  ngOnInit(): void {
    this.chaves = Object.keys(this.tipos).filter(t => !isNaN(Number(t)));

    this.cadastroForm = new FormGroup({

      nome: new FormControl(''),
      endereco: new FormControl(''),
      telefone: new FormControl(''),
      cnpj : new FormControl(''),
      rg: new FormControl(''),
      cpf: new FormControl(''),
      tipo: new FormControl(''),
      email: new FormControl('')
    });
  }

  adicionarCliente() {
    this.clienteVM = Object.assign({}, this.clienteVM, this.cadastroForm.value);

    this.servicoCliente.adicionarEntidade(this.clienteVM)
    .subscribe(
      cliente => {
        this.toastService.show('Cliente ' + cliente.nome + ' adicionado com sucesso!',
          { classname: 'bg-success text-light', delay: 4000 });
        setTimeout(() => {
          this.router.navigate(['cliente/listar']);
        }, 5000);
      },
      erro => {
        this.toastService.show('Erro ao adicionar cliente: ' + erro.error.errors["Nome"].toString(),
          { classname: 'bg-danger text-light', delay: 4000 });
      }
    );
  }

  cancelar(): void {
    this.router.navigate(['cliente/listar']);
  }

}
