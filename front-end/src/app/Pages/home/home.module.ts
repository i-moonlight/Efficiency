import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { HomeRoutingModule } from "./home-routing.module";
import { HomeComponent } from "./home.component";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
    declarations: [HomeComponent],
    imports: [CommonModule, HomeRoutingModule, ReactiveFormsModule],
})
export class HomeModule {}
