import { EmployeeService } from "./Employee/employee.service";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: "root",
})
export class AppService {
    constructor(private _employeeService: EmployeeService) {}
}
