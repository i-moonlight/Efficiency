import { Injectable } from "@angular/core";

@Injectable({
    providedIn: "root",
})
export class TokenService {
    saveToken(jwttoken: string) {
        throw new Error("Method not implemented.");
    }

    constructor() {}
}
