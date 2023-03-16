import { Token } from "./../../Models/Token";
import { Injectable } from "@angular/core";
import { UserService } from "../../Services/User/user.service";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, tap } from "rxjs";
import { LogUserDTO, PostUserDTO, PutUserDTO } from "src/app/Data/DTO/UserDTO";
import { User, Users } from "src/app/Models/User";
import { environment } from "src/environments/environment";

const API: string = environment.backendAPIUrl;
const URL: string = `${API}/user`;

@Injectable({
    providedIn: "root",
})
export class UserController {
    constructor(private _http: HttpClient, private _service: UserService) {}

    Get(id: number): Observable<User> {
        return this._http.get<User>(`${URL}/${id}`);
    }

    LogIn(userDTO: LogUserDTO) {
        return this._http
            .post<Token>(`${API}/login`, userDTO, {
                observe: "response",
                headers: new HttpHeaders({
                    "Content-Type": "application/json",
                }),
            })
            .pipe(
                tap((response) => {
                    const token = response.body?.Value;
                    if (token !== undefined) {
                        this._service.saveToken(token);
                    }
                })
            );
    }

    GetAll(skip: number = 0, take: number = 50): Observable<Users> {
        return this._http.get<Users>(`${URL}?skip=${skip}&take=${take}`);
    }

    Delete(id: number): Observable<User> {
        return this._http.delete<User>(`${URL}/${id}`);
    }

    Post(userDTO: PostUserDTO) {
        return this._http.post(`${URL}`, userDTO);
    }

    Put(userDTO: PutUserDTO) {
        return this._http.put(`${URL}`, userDTO);
    }
}