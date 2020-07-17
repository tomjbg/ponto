import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export abstract class BaseService {

constructor() { }


protected urlbase = environment.urlBase;

// protected hearders: HttpHeaders = new HttpHeaders() {
//   'headers': { 'Content-Type': 'application/json'}
// }

}
