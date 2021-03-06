import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './navegacao/footer/footer.component';
import { HeaderComponent } from './navegacao/header/header.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { HomeComponent } from './home/home.component';
import { ParceiroListarComponent } from './parceiro/listar/parceiro-listar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ParceiroCriarComponent } from './parceiro/criar/parceiro-criar.component';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ParceiroEditarComponent } from './parceiro/editar/parceiro-editar.component';
import { CupomListarComponent } from './cupom/listar/cupom-listar.component';
import { CupomCriarComponent } from './cupom/criar/cupom-criar.component';
import { CupomEditarComponent } from './cupom/editar/cupom-editar.component';
import { HttpParceiroService } from './parceiro/services/http-parceiro.service';
import { HttpCupomService } from './cupom/services/http-cupom.service';
import { FuncionarioCriarComponent } from './funcionario/criar/funcionario-criar.component';
import { FuncionarioListarComponent } from './funcionario/listar/funcionario-listar.component';
import { FuncionarioEditarComponent } from './funcionario/editar/funcionario-editar.component';
import { HttpFuncionarioService } from './funcionario/services/https-funcionario.service';
import { ClienteCriarComponent } from './cliente/criar/cliente-criar.component';
import { HttpClienteService } from './cliente/services/http-cliente.service';
import { ClienteEditarComponent } from './cliente/editar/cliente-editar.component';
import { ClienteListarComponent } from './cliente/listar/cliente-listar.component';
import { ToastContainerComponent } from './shared/components/toast-container.componet';
import { CondutorListarComponent } from './condutor/listar/condutor-listar.component';
import { CondutorEditarComponent } from './condutor/editar/condutor-editar.component';
import { HttpCondutorService } from './condutor/services/http-condutor.service';
import { CondutorCriarComponent } from './condutor/criar/condutor-criar.component';


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    MenuComponent,
    HomeComponent,
    ParceiroListarComponent,
    ParceiroCriarComponent,
    ParceiroEditarComponent,
    CupomListarComponent,
    CupomCriarComponent,
    CupomEditarComponent,
    FuncionarioCriarComponent,
    FuncionarioListarComponent,
    FuncionarioEditarComponent,
    ClienteCriarComponent,
    ClienteEditarComponent,
    ClienteListarComponent,
    ToastContainerComponent,
    CondutorListarComponent,
    CondutorEditarComponent,
    CondutorCriarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    NgbModule
  ],
  providers: [
    { provide: 'IHttpParceiroServiceToken', useClass: HttpParceiroService },
    { provide: 'IHttpCupomServiceToken', useClass: HttpCupomService },
    { provide: 'IHttpFuncionarioServiceToken', useClass: HttpFuncionarioService },
    { provide: 'IHttpClienteServiceToken', useClass: HttpClienteService },
    { provide: 'IHttpCondutorServiceToken', useClass: HttpCondutorService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
