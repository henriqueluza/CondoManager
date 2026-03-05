import { Component, inject, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthServices } from '../../core/services/auth-services';
import { passwordValidator, cpfValidator, cellphoneValidator } from '../../core/validators/custom-validators';

@Component({
  selector: 'app-auth',
  imports: [ReactiveFormsModule],
  templateUrl: './auth.html',
  styleUrl: './auth.css',
})

export class Auth {

  private cdr = inject(ChangeDetectorRef);

  activeTab: 'login' | 'register' = 'login';

  registerForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    cpf: new FormControl('', [Validators.required, cpfValidator]),
    cellphone: new FormControl('', [Validators.required, cellphoneValidator]),
    password: new FormControl('', [Validators.required, passwordValidator]),
  });

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  private auth = inject(AuthServices);
  private router = inject(Router);

  switchTab(tab: 'login' | 'register') {
    this.activeTab = tab;
    this.cdr.detectChanges(); // força o Angular a atualizar o HTML
  }

  onRegister() {
    if (!this.registerForm.valid) return;
    const email = this.registerForm.value.email!;
    const name = this.registerForm.value.name!;
    const cpf = this.registerForm.value.cpf!;
    const cellphone = this.registerForm.value.cellphone!;
    const password = this.registerForm.value.password!;

    this.auth.register(email, name, cpf, cellphone, password).subscribe({
      next: () => {
        console.log('Cadastro ok, trocando para login');
        this.switchTab('login');
      },
      error: () => {
        console.log("Erro")
      }
    })
  }

  onLogin() {
    if (!this.loginForm.valid) return;

    const email = this.loginForm.value.email!;
    const password = this.loginForm.value.password!;

    this.auth.login(email, password).subscribe({
      next: () => {
        this.router.navigate(['/dashboard']);
      },
      error: () => {
        console.error('Credenciais inválidas');
      }
    });
  }
}
