import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
    { path: "", pathMatch: "full", redirectTo: "home" },
    {
        path: "home",
        pathMatch: "full",
        loadChildren: () =>
            import("./Pages/home/home.module").then((m) => m.HomeModule),
    },
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
