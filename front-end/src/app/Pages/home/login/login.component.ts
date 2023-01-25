import { UserController } from "./../../../Controllers/User/user.controller";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { LogUserDTO } from "src/app/Data/DTO/UserDTO";

@Component({
    selector: "app-login",
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
    loginForm!: FormGroup;
    userDTO!: LogUserDTO;

    constructor(
        private _formBuilder: FormBuilder,
        private _router: Router,
        private _userController: UserController
    ) {}

    ngOnInit(): void {
        this.loginForm = this._formBuilder.group({
            email: ["", [Validators.required, Validators.email]],
            password: ["", [Validators.required]],
        });
    }

    forgotPassword() {
        throw new Error("Method not implemented.");
    }

    logIn() {
        if (this.loginForm.valid) {
            this.userDTO = this.loginForm.getRawValue() as LogUserDTO;

            console.table(this.userDTO);

            this._userController.LogIn(this.userDTO).subscribe({
                next: (data) => {},
                error: (error) => {
                    console.error(error);
                },
                complete: () => {
                    this._router.navigate(["/dashboard"]);
                },
            });
        }
    }

    createAccount() {
        this._router.navigate(["signup"]);
    }
}
