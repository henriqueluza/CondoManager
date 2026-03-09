import api from '../../services/api.ts'

export async function login(email: string, password: string) {
    await api.post('user/login', {email, password})
}

export async function register(name: string, email: string, password: string, cellphone: string, cpf: string) {
    await api.post('user/register', {name, email, password, cpf, cellphone})
}

export async function getMe() {
    const response = await api.get('/user/me')
    return response.data
}