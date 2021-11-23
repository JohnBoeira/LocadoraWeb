import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { FuncionarioCreateViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioCreateViewModel';

@Component({
  selector: 'app-funcionario-criar',
  templateUrl: './funcionario-criar.component.html',
})
export class FuncionarioCriarComponent implements OnInit {
  cadastroForm: FormGroup;
  Funcionario: FuncionarioCreateViewModel;

  constructor(@Inject('IHttpFuncionarioServiceToken') private servicoFuncionario: IHttpFuncionarioService, private router: Router, private toastService: ToastService) { }

  ngOnInit(): void {
    this.cadastroForm = new FormGroup({
      nome:       new FormControl(''),
      endereco:   new FormControl(''),
      telefone:   new FormControl(''),
      cnpj :      new FormControl(''),
      rg:         new FormControl(''),
      cpf:        new FormControl(''),
      tipoPessoa: new FormControl(''),
      email:       new FormControl('')
    });
  }

  adicionarFuncionario() {
    this.Funcionario = Object.assign({}, this.Funcionario, this.cadastroForm.value);

    this.servicoFuncionario.adicionarEntidade(this.Funcionario)
    .subscribe(
      funcionario => {
        this.toastService.show('Funcionário ' + funcionario.nome + ' adicionado com sucesso!',
          { classname: 'bg-success text-light', delay: 4000 });
        setTimeout(() => {
          this.router.navigate(['funcionario/listar']);
        }, 5000);
      },
      erro => {
        this.toastService.show('Erro ao adicionar funcionário: ' + erro.error.errors["Nome"].toString(),
          { classname: 'bg-danger text-light', delay: 4000 });
      }
    );
  }

  cancelar(): void {
    this.router.navigate(['funcionario/listar']);
  }

}
