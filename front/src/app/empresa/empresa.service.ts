import { Empresa } from './empresa.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../shared/base.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class EmpresaService extends BaseService {

constructor(private httpClient: HttpClient) { super();  }


public adicionarEmpresa(empresa: Empresa): Observable<object> {

  return this.httpClient.post(this.urlbase + 'api/empresas',
                  empresa,
                   {'headers': { 'Content-Type': 'application/json'}});

}




}
