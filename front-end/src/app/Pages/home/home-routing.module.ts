import { SignupComponent } from "./../signup/signup.component";
import { LoginComponent } from "./../login/login.component";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home.component";

const routes: Routes = [
    {
        path: "",
        component: HomeComponent,
        children: [
            {
                path: "",
                component: LoginComponent,
            },
            {
                path: "signup",
                component: SignupComponent,
            },
            // the object ☝🏻 represents a way to implement lazy component loading
            // the object 👇🏻 represents a standard way to load a component
            // { path: "signup", component: SignupComponent },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class HomeRoutingModule {}
