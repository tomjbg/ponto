import { EmpresaService } from './empresa.service';
import { Component, OnInit } from '@angular/core';
import { Empresa } from './empresa.model';

@Component({
  selector: 'ponto-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.scss']
})
export class EmpresaComponent implements OnInit {

  constructor(private empresaService: EmpresaService) { }

  ngOnInit() {
  }

  public addEmpresa(): void {

    console.error('Cadastrando empresa');

    let empresa = new Empresa('Wellington JBG',
                  'TGDS',
                  '60123654000165',
                  '12345678910',
                  '12345678911', 'Web Application Factory');

    this.empresaService.adicionarEmpresa(empresa).subscribe((res) => {
      alert(res);
    }, (err)=> {
      console.log(err);
    });

  }


}
