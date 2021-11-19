import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { FuncionarioCreateViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioCreateViewModel';

@Component({
  selector: 'app-funcionario-criar',
  templateUrl: './funcionario-criar.component.html',
})
export class FuncionarioCriarComponent implements OnInit {
  cadastroForm: FormGroup;
  Funcionario: FuncionarioCreateViewModel;

  constructor(@Inject('IHttpFuncionarioServiceToken') private servicoFuncionario: IHttpFuncionarioService, private router: Router) { }

  ngOnInit(): void {
    this.cadastroForm = new FormGroup({
      nome: new FormControl(''),
      usuario: new FormControl(''),
      senha: new FormControl(''),
      salario: new FormControl(''),
      dataAdmissao: new FormControl('')
    });
  }

  adicionarFuncionario() {
    this.Funcionario = Object.assign({}, this.Funcionario, this.cadastroForm.value);

    this.servicoFuncionario.adicionarEntidade(this.Funcionario)
      .subscribe(() => {
        this.router.navigate(['funcionario/listar']);
      });
  }

  cancelar(): void {
    this.router.navigate(['funcionario/listar']);
  }

}
