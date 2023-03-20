export interface User {
    ID?: number;
    FirstName?: string;
    LastName?: string;
    UserName?: string;
    Role?: string;
    StoreID?: number;
}

export type Users = Array<User>;
