import { Seller, Sellers } from "./../../Models/Seller";
import { ISellerService } from "./../../Interfaces/Services/ISellerService";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment.dev";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PostSellerDTO, PutSellerDTO } from "src/app/Data/DTO/SellerDTO";

const API: string = environment.backendAPIUrl;
const URL: string = `${API}/Seller`;

@Injectable({
    providedIn: "root",
})
export class SellerService implements ISellerService {
    constructor(private _http: HttpClient) {}

    Get(ID: number): Observable<Seller> {
        return this._http.get<Seller>(`${URL}/${ID}`);
    }

    GetAll(skip: number = 0, take: number = 50): Observable<Sellers> {
        return this._http.get<Sellers>(`${URL}?skip=${skip}&take=${take}`);
    }

    Delete(ID: number): Observable<Seller> {
        return this._http.delete<Seller>(`${URL}/${ID}`);
    }

    Post(SellerDTO: PostSellerDTO) {
        return this._http.post(`${URL}`, this.fillPOSTFormData(SellerDTO));
    }

    Put(SellerDTO: PutSellerDTO) {
        return this._http.put(`${URL}`, this.fillPUTFormData(SellerDTO));
    }

    private fillPOSTFormData(SellerDTO: PostSellerDTO): FormData {
        let result: FormData = new FormData();

        result.append("Name", SellerDTO.Name);
        result.append(
            "RegistrationNumber",
            SellerDTO.RegistrationNumber.toString()
        );
        if (SellerDTO.StoreID != null) {
            result.append("StoreID", SellerDTO.StoreID.toString());
        }
        if (SellerDTO.Email != null) {
            result.append("Email", SellerDTO.Email);
        }
        if (SellerDTO.Phone != null) {
            result.append("Phone", SellerDTO.Phone);
        }

        return result;
    }

    private fillPUTFormData(SellerDTO: PutSellerDTO): FormData {
        let result: FormData = new FormData();

        result.append("Name", SellerDTO.Name);
        result.append(
            "RegistrationNumber",
            SellerDTO.RegistrationNumber.toString()
        );
        if (SellerDTO.StoreID != null) {
            result.append("StoreID", SellerDTO.StoreID.toString());
        }
        if (SellerDTO.Email != null) {
            result.append("Email", SellerDTO.Email);
        }
        if (SellerDTO.Phone != null) {
            result.append("Phone", SellerDTO.Phone);
        }

        return result;
    }
}
