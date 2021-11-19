import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { FuncionarioDetailsViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioDetailsViewModel';
import { FuncionarioEditViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioEditViewModel';

@Component({
  selector: 'app-funcionario-editar',
  templateUrl: './funcionario-editar.component.html',
 
})
export class FuncionarioEditarComponent implements OnInit {
  sub: any;
  id: any;
  Funcionario: FuncionarioEditViewModel;
  cadastroForm: FormGroup;

  constructor(private _Activatedroute: ActivatedRoute, @Inject('IHttpFuncionarioServiceToken') private servicoFuncionario: IHttpFuncionarioService, private router: Router) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");

    this.cadastroForm = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl(''),
      usuario: new FormControl(''),
      senha: new FormControl(''),
      salario: new FormControl(''),
      dataAdmissao: new FormControl('')
    });

    this.carregarFuncionario();
  }

  carregarFuncionario() {
    this.servicoFuncionario.obterEntidadePorId(this.id)
      .subscribe((Funcionario: FuncionarioDetailsViewModel) => {
        this.carregarFormulario(Funcionario);
      });
  }

  atualizarFuncionario() {
    this.Funcionario = Object.assign({}, this.Funcionario, this.cadastroForm.value);
    this.Funcionario.id = this.id;

    this.servicoFuncionario.editarEntidade(this.Funcionario)
      .subscribe(() => {
        this.router.navigate(['funcionario/listar']);
      });
  }

  cancelar(): void {
    this.router.navigate(['funcionario/listar']);
  }

  carregarFormulario(Funcionario: FuncionarioDetailsViewModel) {

    this.cadastroForm = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl(''),
      usuario: new FormControl(''),
      senha: new FormControl(''),
      salario: new FormControl(''),
      dataAdmissao: new FormControl('')
    });

   
  }
}
