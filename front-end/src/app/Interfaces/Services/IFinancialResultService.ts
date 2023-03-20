import { PostResultDTO, PutResultDTO } from "./../../Data/DTO/ResultDTO";
import { Result, Results } from "src/app/Models/Result";
import { IService } from "./IService";
import { Observable } from "rxjs";

export interface ISellerService extends IService {
    Get(ID: number): Observable<Result>;
    GetAll(skip: number, take: number): Observable<Results>;
    Delete(ID: number): Observable<Result>;
    Post(fResultDTO: PostResultDTO): Observable<Result>;
    Put(fResultDTO: PutResultDTO): Observable<Result>;
}
