import { UserService } from "./User/user.service";
import { EmployeeService } from "./Employee/employee.service";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: "root",
})
export class AppService {
    constructor(
        private _employeeService: EmployeeService,
        private _userService: UserService
    ) {}

    get userService() {
        return this._userService;
    }

    get employeeService() {
        return this._employeeService;
    }
}
