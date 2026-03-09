export interface Condominium {
    id: string
    name: string
    address: string
    createdAt: string
}

export interface CreateCondominiumDto {
    name: string
    address: string
    userId: string
}