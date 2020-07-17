import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmpresaComponent } from './empresa/empresa.component';
import { EmpresaService } from './empresa/empresa.service';
import { AccountModule } from './Account/account.module';

@NgModule({
   declarations: [
      AppComponent,
      EmpresaComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      AccountModule
   ],
   providers: [
      EmpresaService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
