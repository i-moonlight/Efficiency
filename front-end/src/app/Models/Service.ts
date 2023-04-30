import { ServicesResults } from "./ServiceResult";

export interface Service {
    ID: number;
    Name: string;
    StoreID: number;
    ServicesResult: ServicesResults;
}

export type Services = Array<Service>;
