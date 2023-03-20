export interface Seller {
    RegistrationNumber: number;
    Name: string;
    Phone: string;
    Email: string;
    StoreID: number;
}

export type Sellers = Array<Seller>;
