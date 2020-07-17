import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Registrar } from './registrar.model';

@Component({
  selector: 'ponto-registrar',
  templateUrl: './registrar.component.html'
})
export class RegistrarComponent implements OnInit {

  registrarForm: FormGroup;
  registrar: Registrar = new Registrar();

  constructor(private fb: FormBuilder) {

    this.registrarForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(4)]],
      password: this.fb.control('', [Validators.required, Validators.minLength(6)]),
      confirmPassword: this.fb.control('', [Validators.required, Validators.minLength(6)])
    });

   }

  ngOnInit() {

  }

  get username() { return this.registrarForm.get('username'); }
  get password() { return this.registrarForm.get('password'); }
  get confirmPassword() { return this.registrarForm.get('confirmPassword'); }


  cadastrar(): void {
    console.log(this.registrarForm.value);
  }



}
