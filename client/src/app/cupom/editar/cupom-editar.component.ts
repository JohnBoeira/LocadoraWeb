import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { IHttpCupomService } from 'src/app/shared/interfaces/IHttpCupomService';
import { IHttpParceiroService } from 'src/app/shared/interfaces/IHttpParceiroService';
import { CupomType } from 'src/app/shared/models/CupomEnum';
import { CupomDetailsViewModel } from 'src/app/shared/viewModels/cupom/CupomDetailsViewModel';
import { CupomEditViewModel } from 'src/app/shared/viewModels/cupom/CupomEditViewModel';
import { ParceiroListViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroListViewModel';

@Component({
  selector: 'app-cupom-editar',
  templateUrl: './cupom-editar.component.html'
})
export class CupomEditarComponent implements OnInit {

  cadastroForm: FormGroup;
  id: any;
  cupom: CupomEditViewModel;
  listaParceiros: ParceiroListViewModel[];

  tipos = CupomType;
  chaves: any[];

  constructor(private _Activatedroute: ActivatedRoute,
    @Inject('IHttpCupomServiceToken') private servicoCupom: IHttpCupomService,
    @Inject('IHttpParceiroServiceToken') private servicoParceiro: IHttpParceiroService,
    private router: Router) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");

    this.chaves = Object.keys(this.tipos).filter(t => !isNaN(Number(t)));

    this.cadastroForm = new FormGroup({
      nome: new FormControl(''),
      valor: new FormControl(''),
      valorMinimo: new FormControl(''),
      dataValidade: new FormControl(''),
      parceiroId: new FormControl(''),
      tipo: new FormControl('')
    });

    this.carregarParceiros();
    this.carregarCupom();
  }

  carregarParceiros(): void {
    this.servicoParceiro.obterEntidades()
      .subscribe(parceiros => {
        this.listaParceiros = parceiros;
      });
  }

  carregarCupom(): void {
    this.servicoCupom.obterEntidadePorId(this.id)
      .subscribe((cupom: CupomDetailsViewModel) => {
        this.carregarFormulario(cupom);
      });
  }

  carregarFormulario(cupom: CupomDetailsViewModel) {

    this.cadastroForm = new FormGroup({
      nome: new FormControl(cupom.nome),
      valor: new FormControl(cupom.valor),
      valorMinimo: new FormControl(cupom.valorMinimo),
      dataValidade: new FormControl(cupom.dataValidade.toLocaleString().substring(0, 10)),
      parceiroId: new FormControl(cupom.id),
      tipo: new FormControl(cupom.tipo)
    });
  }

  atualizarCupom() {
    this.cupom = Object.assign({}, this.cupom, this.cadastroForm.value);
    this.cupom.id = this.id;

    this.servicoCupom.editarEntidade(this.cupom)
      .subscribe(() => {
        this.router.navigate(['cupom/listar']);
      });
  }

  cancelar(): void {
    this.router.navigate(['cupom/listar']);
  }
}
