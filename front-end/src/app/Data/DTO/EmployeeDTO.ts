export interface PostSellerDTO {
    RegistrationNumber: number;
    Name: string;
    Phone?: string;
    Email?: string;
    StoreID?: number;
}

export interface PutSellerDTO {
    RegistrationNumber: number;
    Name: string;
    Phone?: string;
    Email?: string;
    StoreID?: number;
}
