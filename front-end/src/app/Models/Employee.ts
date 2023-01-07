export interface Employee {
    RegistrationNumber: number;
    Name: string;
    Phone: string;
    Email: string;
    CompanyID: number;
}

export type Employees = Array<Employee>;
