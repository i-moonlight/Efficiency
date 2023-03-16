import { Employee, Employees } from "./../../Models/Employee";
import { IEmployeeService } from "./../../Interfaces/Services/IEmployeeService";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment.dev";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PostEmployeeDTO, PutEmployeeDTO } from "src/app/Data/DTO/EmployeeDTO";

const API: string = environment.backendAPIUrl;
const URL: string = `${API}/Employee`;

@Injectable({
    providedIn: "root",
})
export class EmployeeService implements IEmployeeService {
    constructor(private _http: HttpClient) {}

    Get(id: number): Observable<Employee> {
        return this._http.get<Employee>(`${URL}/${id}`);
    }

    GetAll(skip: number = 0, take: number = 50): Observable<Employees> {
        return this._http.get<Employees>(`${URL}?skip=${skip}&take=${take}`);
    }

    Delete(id: number): Observable<Employee> {
        return this._http.delete<Employee>(`${URL}/${id}`);
    }

    Post(employeeDTO: PostEmployeeDTO) {
        return this._http.post(`${URL}`, this.fillPOSTFormData(employeeDTO));
    }

    Put(employeeDTO: PutEmployeeDTO) {
        return this._http.put(`${URL}`, this.fillPUTFormData(employeeDTO));
    }

    private fillPOSTFormData(employeeDTO: PostEmployeeDTO): FormData {
        let result: FormData = new FormData();

        result.append("Name", employeeDTO.Name);
        result.append(
            "RegistrationNumber",
            employeeDTO.RegistrationNumber.toString()
        );
        if (employeeDTO.CompanyID != null) {
            result.append("CompanyID", employeeDTO.CompanyID.toString());
        }
        if (employeeDTO.Email != null) {
            result.append("Email", employeeDTO.Email);
        }
        if (employeeDTO.Phone != null) {
            result.append("Phone", employeeDTO.Phone);
        }

        return result;
    }

    private fillPUTFormData(employeeDTO: PutEmployeeDTO): FormData {
        let result: FormData = new FormData();

        result.append("Name", employeeDTO.Name);
        result.append(
            "RegistrationNumber",
            employeeDTO.RegistrationNumber.toString()
        );
        if (employeeDTO.CompanyID != null) {
            result.append("CompanyID", employeeDTO.CompanyID.toString());
        }
        if (employeeDTO.Email != null) {
            result.append("Email", employeeDTO.Email);
        }
        if (employeeDTO.Phone != null) {
            result.append("Phone", employeeDTO.Phone);
        }

        return result;
    }
}
