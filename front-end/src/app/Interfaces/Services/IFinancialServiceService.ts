import {
    FinancialService,
    FinancialServices,
} from "src/app/Models/FinancialService";
import { IService } from "./IService";
import { Observable } from "rxjs";

export interface IEmployeeService extends IService {
    Get(id: number): Observable<FinancialService>;
    GetAll(skip: number, take: number): Observable<FinancialServices>;
    Delete(id: number): Observable<FinancialService>;
    Post(): Observable<FinancialService>;
    Put(): Observable<FinancialService>;
}
