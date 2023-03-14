import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { Component } from "@angular/core";
import { User } from "src/app/Models/User";
import { UserService } from "src/app/Services/User/user.service";

@Component({
    selector: "app-header",
    templateUrl: "./header.component.html",
    styleUrls: ["./header.component.scss"],
})
export class HeaderComponent {
    userAuthenticated: boolean;
    user$: Observable<User>;

    constructor(private _userService: UserService, private _router: Router) {
        this.userAuthenticated = this._userService.isUserLoggedIn();
        this.user$ = this._userService.returnUser();
    }

    logout() {
        this._userService.logOut();
    }

    login() {
        this._router.navigate([""]);
    }

    signup() {
        this._router.navigate(["home/signup"]);
    }
}
