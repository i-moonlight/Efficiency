import { Observable } from "rxjs";

export interface IService {
    Get(id: number): Observable<any>;
    GetAll(skip: number, take: number): Observable<any>;
    Delete(id: number): Observable<any>;
}
