export type MemberRole = 'Syndic' | 'Resident' | 'Employee'

export interface Member {
    id: string
    name: string
    email: string
    phone: string
    role: MemberRole
    condominiumId: string
}

export interface CreateResidentDto {
    name: string
    email: string
    phone: string
    apartment: string
    block: string
    condominiumId: string
}

export interface CreateSyndicDto {
    name: string
    email: string
    phone: string
    mandateStartDate: string
    mandateEndDate: string
    condominiumId: string
}