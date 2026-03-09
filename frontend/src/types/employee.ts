export interface Employee {
    id: string
    name: string
    email: string
    phone: string
    position: string
    shift: string
    condominiumId: string
}

export interface CreateEmployeeDto {
    name: string
    email: string
    phone: string
    position: string
    shift: string
    condominiumId: string
}