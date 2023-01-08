import {
    PostFinancialServiceDTO,
    PutFinancialServiceDTO,
} from "./../../Data/DTO/FinancialServiceDTO";
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
    Post(fServiceDTO: PostFinancialServiceDTO): Observable<FinancialService>;
    Put(fServiceDTO: PutFinancialServiceDTO): Observable<FinancialService>;
}
