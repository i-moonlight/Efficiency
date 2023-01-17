import { LogUserDTO } from "./../../Data/DTO/UserDTO";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
    selector: "app-home",
    templateUrl: "./home.component.html",
    styleUrls: ["./home.component.css"],
})
export class HomeComponent implements OnInit {
    loginForm!: FormGroup;
    userDTO!: LogUserDTO;

    constructor(private _formBuilder: FormBuilder, private _router: Router) {}

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
        } else {
            console.error(
                "Oops. Something you inserted is wrong. Please, check everything and try again!"
            );
            console.error(this.loginForm);
        }
    }
}
