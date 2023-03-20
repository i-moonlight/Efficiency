import { PostServiceDTO, PutServiceDTO } from "./../../Data/DTO/ServiceDTO";
import { Service, Services } from "src/app/Models/Service";
import { IService } from "./IService";
import { Observable } from "rxjs";

export interface ISellerService extends IService {
    Get(ID: number): Observable<Service>;
    GetAll(skip: number, take: number): Observable<Services>;
    Delete(ID: number): Observable<Service>;
    Post(fServiceDTO: PostServiceDTO): Observable<Service>;
    Put(fServiceDTO: PutServiceDTO): Observable<Service>;
}
