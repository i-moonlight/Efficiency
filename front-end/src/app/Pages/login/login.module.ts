import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { LoginComponent } from "./login.component";
import { MessageModule } from "../message/message.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
    declarations: [LoginComponent],
    imports: [
        CommonModule,
        MessageModule,
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
    ],
})
export class LoginModule {}
