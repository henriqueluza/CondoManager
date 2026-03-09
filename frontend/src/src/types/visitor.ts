export type VisitorStatus = 'Pending' | 'Approved' | 'Denied' | 'CheckedIn' | 'CheckedOut'

export interface Visitor {
    id: string
    name: string
    cpf: string
    status: VisitorStatus
    dateOfVisit: string
    authorizedById: string
    condominiumId: string
}

export interface CreateVisitorDto {
    name: string
    cpf: string
    dateOfVisit: string
    authorizedById: string
    condominiumId: string
}