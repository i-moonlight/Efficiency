import { PostCompanyDTO, PutCompanyDTO } from "./../../Data/DTO/CompanyDTO";
import { Company, Companies } from "src/app/Models/Company";
import { IService } from "./IService";
import { Observable } from "rxjs";

export interface IEmployeeService extends IService {
    Get(id: number): Observable<Company>;
    GetAll(skip: number, take: number): Observable<Companies>;
    Delete(id: number): Observable<Company>;
    Post(companyDTO: PostCompanyDTO): Observable<Company>;
    Put(companyDTO: PutCompanyDTO): Observable<Company>;
}
