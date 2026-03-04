import { Component, inject } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Auth } from '../../../core/services/auth';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  // 1. O formulário com suas validações
  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  // 2. Injeta o service de autenticação e o Router (para redirecionar)
  private auth = inject(Auth);
  private router = inject(Router);

  onSubmit() {
    // 3. Só continua se o formulário for válido
    if (!this.form.valid) return;

    // 4. Pega os valores do formulário
    const email = this.form.value.email!;
    const password = this.form.value.password!;

    // 5. Chama o service — o subscribe() faz o POST executar de verdade
    this.auth.login(email, password).subscribe({
      next: () => {
        // 6. Login ok — redireciona para o dashboard
        this.router.navigate(['/dashboard']);
      },
      error: () => {
        // 7. Login falhou — por enquanto só loga no console
        console.error('Credenciais inválidas');
      }
    });
  }
}
