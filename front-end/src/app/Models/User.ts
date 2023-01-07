export interface User {
    ID: number;
    FirstName: string;
    LastName: string;
    UserName: string;
    Role: string;
    CompanyID?: number;
}

export type Users = Array<User>;
