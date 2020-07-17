import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmpresaComponent } from './empresa/empresa.component';
import { LoginComponent } from './Account/login/login.component';
import { RegistrarComponent } from './Account/registrar/registrar.component';

const routes: Routes = [
  { path: '', component: LoginComponent},
  { path: 'registrar', component: RegistrarComponent},
  { path: 'empresas', component: EmpresaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
