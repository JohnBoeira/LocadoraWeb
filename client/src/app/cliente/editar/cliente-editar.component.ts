import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IHttpClienteService } from 'src/app/shared/interfaces/IHttpsClienteService';
import { CupomType } from 'src/app/shared/models/CupomEnum';
import { ClienteDetailsViewModel } from 'src/app/shared/viewModels/Cliente/ClienteDetails';
import { ClienteEditViewModel } from 'src/app/shared/viewModels/Cliente/ClienteEditViewModel';

@Component({
  selector: 'app-cliente-editar',
  templateUrl: './cliente-editar.component.html',
 
})
export class ClienteEditarComponent implements OnInit {

  sub: any;
  id: any;
  clienteVM: ClienteEditViewModel;
  cadastroForm: FormGroup;

  tipos = CupomType;
  chaves: any[];

  constructor(private _Activatedroute: ActivatedRoute, @Inject('IHttpClienteServiceToken') private servicoCliente: IHttpClienteService, private router: Router) { }

  ngOnInit(): void {
    this.chaves = Object.keys(this.tipos).filter(t => !isNaN(Number(t)));
    this.id = this._Activatedroute.snapshot.paramMap.get("id");

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

    this.carregarCliente();
  }

  carregarCliente() {
    this.servicoCliente.obterEntidadePorId(this.id)
      .subscribe((Cliente: ClienteDetailsViewModel) => {
        this.carregarFormulario(Cliente);
      });
  }

  atualizarCliente() {
    this.clienteVM = Object.assign({}, this.clienteVM, this.cadastroForm.value);
    this.clienteVM.id = this.id;

    this.servicoCliente.editarEntidade(this.clienteVM)
      .subscribe(() => {
        this.router.navigate(['cliente/listar']);
      });
  }

  cancelar(): void {
    this.router.navigate(['cliente/listar']);
  }

  carregarFormulario(Cliente: ClienteDetailsViewModel) {
    
    this.cadastroForm = new FormGroup({
      nome: new FormControl(Cliente.nome),
      endereco: new FormControl(Cliente.endereco),
      telefone: new FormControl(Cliente.telefone),
      cnpj : new FormControl(Cliente.cnpj),
      rg: new FormControl(Cliente.rg),
      cpf: new FormControl(Cliente.cpf),
      tipo: new FormControl(Cliente.tipo),
      email: new FormControl(Cliente.email)
    });
  }

}
