import { PostStoreDTO, PutStoreDTO } from "./../../Data/DTO/StoreDTO";
import { Store, Companies } from "src/app/Models/Store";
import { IService } from "./IService";
import { Observable } from "rxjs";

export interface ISellerService extends IService {
    Get(ID: number): Observable<Store>;
    GetAll(skip: number, take: number): Observable<Companies>;
    Delete(ID: number): Observable<Store>;
    Post(StoreDTO: PostStoreDTO): Observable<Store>;
    Put(StoreDTO: PutStoreDTO): Observable<Store>;
}
