export interface AccessLog {
    id: string
    visitorId: string
    employeeId: string
    timeOfEntry: string
    timeOfExit: string | null
    condominiumId: string
}

export interface CreateAccessLogDto {
    visitorId: string
    employeeId: string
    condominiumId: string
}