import { Injectable } from "@angular/core";
import { BehaviorSubject, ReplaySubject, Subject } from "rxjs";
import { User } from "src/app/Models/User";
import { TokenService } from "../Token/token.service";

import jwt_decode from "jwt-decode";

@Injectable({
    providedIn: "root",
})
export class UserService {
    private userSubject = new BehaviorSubject<User>({});

    constructor(private _tokenService: TokenService) {
        if (this._tokenService.hasToken()) {
            this.decodeJWT();
        }
    }

    decodeJWT() {
        const token = this._tokenService.returnToken();
        const user = jwt_decode(token) as User;

        this.userSubject.next(user);
    }

    saveToken(token: string) {
        this._tokenService.saveToken(token);
        this.decodeJWT();
    }

    returnUser() {
        return this.userSubject.asObservable();
    }

    logOut() {
        this._tokenService.deleteToken();
        this.userSubject.next({});
    }

    isUserLoggedIn() {
        return this._tokenService.hasToken();
    }
}
