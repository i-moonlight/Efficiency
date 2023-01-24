import { PostUserDTO } from "./../../../Data/DTO/UserDTO";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
    selector: "app-signup",
    templateUrl: "./signup.component.html",
    styleUrls: ["./signup.component.scss"],
})
export class SignupComponent implements OnInit {
    loginForm!: FormGroup;
    userDTO!: PostUserDTO;

    constructor(private _formBuilder: FormBuilder, private _router: Router) {}

    ngOnInit(): void {
        this.loginForm = this._formBuilder.group({
            firstName: ["", Validators.required],
            lastName: ["", Validators.required],
            phone: ["", Validators.required],
            role: ["", Validators.required],
            email: ["", [Validators.required, Validators.email]],
            password: ["", [Validators.required]],
        });
    }

    forgotPassword() {
        throw new Error("Method not implemented.");
    }

    logIn() {
        if (this.loginForm.valid) {
            this.userDTO = this.loginForm.getRawValue() as PostUserDTO;

            console.table(this.userDTO);

            this._router.navigate(["/dashboard"]);
        }
    }

    createAccount() {
        this._router.navigate(["signup"]);
    }
}
