import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { LogUserDTO, PostUserDTO, PutUserDTO } from "src/app/Data/DTO/UserDTO";
import { User, Users } from "src/app/Models/User";
import { environment } from "src/environments/environment";
import { TokenService } from "../Token/token.service";
import { ThisReceiver } from "@angular/compiler";

const API: string = environment.backendAPIUrl;
const URL: string = `${API}/user`;

@Injectable({
    providedIn: "root",
})
export class UserService {
    constructor(
        private _http: HttpClient,
        private _tokenService: TokenService
    ) {}

    Get(id: number): Observable<User> {
        return this._http.get<User>(`${URL}/${id}`);
    }

    LogIn(userDTO: LogUserDTO) {
        return this._http
            .post(`${API}/login`, this.fillLOGFormData(userDTO), {
                observe: "response",
            })
            .pipe(
                tap((response) => {
                    const jwttoken =
                        response.headers.get("x-access-token") ?? "";
                    this._tokenService.saveToken(jwttoken);
                })
            );
    }

    GetAll(skip: number = 0, take: number = 50): Observable<Users> {
        return this._http.get<Users>(`${URL}?skip=${skip}&take=${take}`);
    }

    Delete(id: number): Observable<User> {
        return this._http.delete<User>(`${URL}/${id}`);
    }

    Post(UserDTO: PostUserDTO) {
        return this._http.post(`${URL}`, this.fillPOSTFormData(UserDTO));
    }

    Put(UserDTO: PutUserDTO) {
        return this._http.put(`${URL}`, this.fillPUTFormData(UserDTO));
    }

    private fillPOSTFormData(UserDTO: PostUserDTO): FormData {
        let result: FormData = new FormData();

        result.append("Password", UserDTO.Password);
        result.append("FirstName", UserDTO.FirstName);
        result.append("LastName", UserDTO.LastName);
        result.append("Phone", UserDTO.Phone);
        result.append("Email", UserDTO.Email);
        result.append("Role", UserDTO.Role);

        if (UserDTO.CompanyID != null) {
            result.append("CompanyID", UserDTO.CompanyID.toString());
        }

        return result;
    }

    private fillLOGFormData(UserDTO: LogUserDTO): FormData {
        let result: FormData = new FormData();

        result.append("Password", UserDTO.Password);
        result.append("Email", UserDTO.Email);

        return result;
    }

    private fillPUTFormData(UserDTO: PutUserDTO): FormData {
        let result: FormData = new FormData();

        result.append("ID", UserDTO.ID.toString());
        result.append("Password", UserDTO.Password);
        if (UserDTO.CompanyID != null) {
            result.append("CompanyID", UserDTO.CompanyID.toString());
        }
        if (UserDTO.Email != null) {
            result.append("Email", UserDTO.Email);
        }
        if (UserDTO.Phone != null) {
            result.append("Phone", UserDTO.Phone);
        }
        if (UserDTO.Role != null) {
            result.append("Phone", UserDTO.Role);
        }
        if (UserDTO.LastName != null) {
            result.append("Phone", UserDTO.LastName);
        }
        if (UserDTO.FirstName != null) {
            result.append("Phone", UserDTO.FirstName);
        }

        return result;
    }
}
