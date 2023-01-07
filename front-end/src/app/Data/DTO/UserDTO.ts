export interface PostUserDTO {
    Password: string;
    FirstName: string;
    LastName: string;
    Phone: string;
    Email: string;
    Role: string;
    CompanyID?: number;
}

export interface PutUserDTO {
    ID: number;
    Password: string;
    FirstName?: string;
    LastName?: string;
    Phone?: string;
    Email?: string;
    Role?: string;
    CompanyID?: number;
}
