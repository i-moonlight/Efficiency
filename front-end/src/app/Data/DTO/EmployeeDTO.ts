export interface PostEmployeeDTO {
    RegistrationNumber: number;
    Name: string;
    Phone?: string;
    Email?: string;
    CompanyID?: number;
}

export interface PutEmployeeDTO {
    RegistrationNumber: number;
    Name: string;
    Phone?: string;
    Email?: string;
    CompanyID?: number;
}
