import { User, Users } from "src/app/Models/User";
import { IService } from "./IService";
import { Observable } from "rxjs";

export interface IEmployeeService extends IService {
    Get(id: number): Observable<User>;
    GetAll(skip: number, take: number): Observable<Users>;
    Delete(id: number): Observable<User>;
    Post(): Observable<User>;
    Put(): Observable<User>;
}
