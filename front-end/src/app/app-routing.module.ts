import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
    {
        path: "",
        pathMatch: "full",
        redirectTo: "home",
    },
    {
        path: "home",
        loadChildren: () =>
            import("./Pages/home/home.module").then((m) => m.HomeModule),
    },
    { path: 'recover-password', loadChildren: () => import('./Pages/recover-password/recover-password.module').then(m => m.RecoverPasswordModule) },
];

/**
 * To create new components with routing enabled and configured automatically
 * use something like:
 * ng generate module <component> --route <component> --module app.module
 **/

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
