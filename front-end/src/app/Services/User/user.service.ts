import { Injectable } from "@angular/core";
import { ReplaySubject, Subject } from "rxjs";
import { User } from "src/app/Models/User";
import { TokenService } from "../Token/token.service";

import jwt_decode from "jwt-decode";

@Injectable({
    providedIn: "root",
})
export class UserService {
    private userSubject: Subject<User | null> =
        new ReplaySubject<User | null>();

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
        this.userSubject.next(null);
    }

    isUserLoggedIn() {
        return this._tokenService.hasToken();
    }
}
