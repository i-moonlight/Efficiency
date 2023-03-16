import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { Component } from "@angular/core";
import { User } from "src/app/Models/User";
import { UserService } from "src/app/Services/User/user.service";
import { UserController } from "src/app/Controllers/User/user.controller";

@Component({
    selector: "app-header",
    templateUrl: "./header.component.html",
    styleUrls: ["./header.component.scss"],
})
export class HeaderComponent {
    userAuthenticated: boolean = false;
    user$: Observable<User>;

    constructor(
        private _userController: UserController,
        private _router: Router
    ) {
        this.user$ = this._userController.GetLoggedUser();
    }

    isUserAuthenticated() {
        this.user$.subscribe({
            next: (user) => {
                this.userAuthenticated = user.FirstName?.length != undefined;
            },
        });

        return this.userAuthenticated;
    }

    logOut() {
        this._userController.logOut();
        this.user$ = this._userController.GetLoggedUser();
        this.userAuthenticated = false;
        this._router.navigate(["home"]);
    }
}
