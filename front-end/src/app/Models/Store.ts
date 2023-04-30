import { Services } from "src/app/Models/Service";
import { Sellers } from "./Seller";
import { Goals } from "./Goal";
import { Users } from "./User";

export interface Store {
    ID: number;
    Name: string;
    City: string;

    State: string;
    Country: string;
    AddressLine1: string;
    AddressLine2: string;
    ZipCode: string;

    Users: Users;

    Sellers: Sellers;

    Goals: Goals;

    Services: Services;
}

export type Companies = Array<Store>;
