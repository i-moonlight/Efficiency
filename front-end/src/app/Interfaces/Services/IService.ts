import { Observable } from "rxjs";

export interface IService {
    Get(ID: number): Observable<any>;
    GetAll(skip: number, take: number): Observable<any>;
    Delete(ID: number): Observable<any>;
}
