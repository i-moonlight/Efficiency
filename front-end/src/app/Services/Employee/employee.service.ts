import { HttpClient } from "@angular/common/http";
import { environment } from "./../../../environments/environment";
import { Injectable } from "@angular/core";

const API: string = environment.backendAPIUrl;

@Injectable({
    providedIn: "root",
})
export class EmployeeService {
    constructor(private _http: HttpClient) {}

    getAll() {
        return this._http.get(`${API}/employee`);
    }

    get(id: number) {
        return this._http.get(`${API}/employee/${id}`);
    }
}
