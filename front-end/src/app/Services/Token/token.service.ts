import { Injectable } from "@angular/core";

const KEY: string = "token";

@Injectable({
    providedIn: "root",
})
export class TokenService {
    hasToken() {
        return !!this.returnToken();
    }

    returnToken() {
        return localStorage.getItem(KEY) ?? "";
    }

    saveToken(token: string) {
        localStorage.setItem(KEY, token);
    }

    deleteToken() {
        localStorage.removeItem(KEY);
    }
}
