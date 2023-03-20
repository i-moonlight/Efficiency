export interface PostUserDTO {
    Password: string;
    FirstName: string;
    LastName: string;
    Phone: string;
    Email: string;
    Role: string;
    StoreID?: number;
}

export interface PutUserDTO {
    ID: number;
    Password: string;
    FirstName?: string;
    LastName?: string;
    Phone?: string;
    Email?: string;
    Role?: string;
    StoreID?: number;
}

export interface LogUserDTO {
    Email: string;
    Password: string;
}

export interface GetUserDTO {
    ID?: number;
    FirstName?: string;
    LastName?: string;
    Phone?: string;
    Email?: string;
    Role?: string;
    StoreID?: number;
}
