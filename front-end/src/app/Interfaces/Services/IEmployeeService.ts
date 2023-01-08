import { Employee, Employees } from "src/app/Models/Employee";
import { IService } from "./IService";
import { Observable } from "rxjs";
import { PostEmployeeDTO, PutEmployeeDTO } from "src/app/Data/DTO/EmployeeDTO";

export interface IEmployeeService extends IService {
    Get(id: number): Observable<Employee>;
    GetAll(skip: number, take: number): Observable<Employees>;
    Delete(id: number): Observable<Employee>;
    Post(employeeDTO: PostEmployeeDTO): Observable<any>;
    Put(employeeDTO: PutEmployeeDTO): Observable<any>;
}
