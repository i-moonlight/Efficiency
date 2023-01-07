import {
    FinancialResult,
    FinancialResults,
} from "src/app/Models/FinancialResult";
import { IService } from "./IService";
import { Observable } from "rxjs";

export interface IEmployeeService extends IService {
    Get(id: number): Observable<FinancialResult>;
    GetAll(skip: number, take: number): Observable<FinancialResults>;
    Delete(id: number): Observable<FinancialResult>;
    Post(): Observable<FinancialResult>;
    Put(): Observable<FinancialResult>;
}
