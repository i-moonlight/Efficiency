import { Seller, Sellers } from "src/app/Models/Seller";
import { IService } from "./IService";
import { Observable } from "rxjs";
import { PostSellerDTO, PutSellerDTO } from "src/app/Data/DTO/SellerDTO";

export interface ISellerService extends IService {
    Get(ID: number): Observable<Seller>;
    GetAll(skip: number, take: number): Observable<Sellers>;
    Delete(ID: number): Observable<Seller>;
    Post(SellerDTO: PostSellerDTO): Observable<any>;
    Put(SellerDTO: PutSellerDTO): Observable<any>;
}
