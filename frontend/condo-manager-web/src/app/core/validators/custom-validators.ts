import {AbstractControl} from '@angular/forms';

export function passwordValidator(control: AbstractControl) {
  const valor = control.value;

  const temMaiuscula = /[A-Z]/.test(valor);
  const temNumero = /[0-9]/.test(valor);
  const temSimbolo = /[@$!%*?&]/.test(valor);

  if (!temMaiuscula || !temNumero || !temSimbolo) {
    return { senhaFraca: true };
  }

  return null;
}
export function cpfValidator(control: AbstractControl) {
  const cpf = control.value?.replace(/[^\d]/g, '');

  if (!cpf || cpf.length !== 11 || /^(\d)\1+$/.test(cpf)) {
    return { cpfInvalido: true };
  }

  // Calcula primeiro dígito
  let soma = 0;
  for (let i = 0; i < 9; i++) {
    soma += parseInt(cpf[i]) * (10 - i);
  }
  let resto = soma % 11;
  const digito1 = resto < 2 ? 0 : 11 - resto;

  // Calcula segundo dígito
  soma = 0;
  for (let i = 0; i < 10; i++) {
    soma += parseInt(cpf[i]) * (11 - i);
  }
  resto = soma % 11;
  const digito2 = resto < 2 ? 0 : 11 - resto;

  // Verifica se os dígitos batem
  if (parseInt(cpf[9]) !== digito1 || parseInt(cpf[10]) !== digito2) {
    return { cpfInvalido: true };
  }

  return null;

}
export function cellphoneValidator(control: AbstractControl) {

  const valor = control.value;

  if (!valor) return null;

  const formato = /^\(\d{2}\) \d{5}-\d{4}$/.test(valor);

  if (!formato) {
    return { telefoneInvalido: true };
  }

  return null;

}
