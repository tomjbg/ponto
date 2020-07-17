export class Empresa {

  constructor(razaosocial: string,
              nomefantasia: string,
              cnpj: string,
              ie: string,
              im: string,
              ramoatividade: string) {
    this.razaoSocial = razaosocial;
    this.nomeFantasia = nomefantasia;
    this.cnpj = cnpj;
    this.ie = ie;
    this.im = im;
    this.ramoAtividade = ramoatividade;
  }
  private readonly Id: string;
  private readonly razaoSocial: string;
  private readonly nomeFantasia: string;
  private readonly cnpj: string;
  private readonly ie: string;
  private readonly im: string;
  private readonly ramoAtividade: string;

}
