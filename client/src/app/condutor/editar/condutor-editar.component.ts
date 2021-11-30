import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IHttpCondutorService } from 'src/app/shared/interfaces/IHttpCondutorService';
import { IHttpClienteService } from 'src/app/shared/interfaces/IHttpsClienteService';
import { ClienteListViewModel } from 'src/app/shared/viewModels/Cliente/ClienteListViewModel';
import { CondutorDetailsViewModel } from 'src/app/shared/viewModels/condutor/CondutorDetailsViewModel';
import { CondutorEditViewModel } from 'src/app/shared/viewModels/condutor/CondutorEditViewModel';

@Component({
  selector: 'app-condutor-editar',
  templateUrl: './condutor-editar.component.html',
  
})
export class CondutorEditarComponent implements OnInit {
  
  cadastroForm: FormGroup;
  id: any;
  Condutor: CondutorEditViewModel;
  listaClientes: ClienteListViewModel[];

  chaves: any[];

  constructor(private _Activatedroute: ActivatedRoute,
    @Inject('IHttpCondutorServiceToken') private servicoCondutor: IHttpCondutorService,
    @Inject('IHttpClienteServiceToken') private servicoCliente: IHttpClienteService,
    private router: Router) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");

    this.cadastroForm = new FormGroup({
      nome: new FormControl(''),
      endereco: new FormControl(''),
      telefone: new FormControl(''),
      rg: new FormControl(''),
      cpf: new FormControl(''),
      cnh: new FormControl(''),
      dataValidade: new FormControl(''),
      ClienteId: new FormControl(''),
    });

    this.carregarClientes();
    this.carregarCondutor();
  }

  carregarClientes(): void {
    this.servicoCliente.obterEntidades()
      .subscribe(Clientes => {
        this.listaClientes = Clientes;
      });
  }

  carregarCondutor(): void {
    this.servicoCondutor.obterEntidadePorId(this.id)
      .subscribe((Condutor: CondutorDetailsViewModel) => {
        this.carregarFormulario(Condutor);
      });
  }

  carregarFormulario(Condutor: CondutorDetailsViewModel) {

    this.cadastroForm = new FormGroup({
      nome: new FormControl(Condutor.nome),
      endereco: new FormControl(Condutor.endereco),
      telefone: new FormControl(Condutor.telefone),
      rg: new FormControl(Condutor.rg),
      cpf: new FormControl(Condutor.cpf),
      cnh: new FormControl(Condutor.cnh),
      dataValidade: new FormControl(Condutor.dataValidadeCnh.toLocaleString().substring(0, 10)),
      ClienteId: new FormControl(Condutor.clienteId),
   
    });
  }

  atualizarCondutor() {
    this.Condutor = Object.assign({}, this.Condutor, this.cadastroForm.value);
    this.Condutor.id = this.id;

    this.servicoCondutor.editarEntidade(this.Condutor)
      .subscribe(() => {
        this.router.navigate(['condutor/listar']);
      });
  }

  cancelar(): void {
    this.router.navigate(['condutor/listar']);
  }

}
