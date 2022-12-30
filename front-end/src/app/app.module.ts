import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HeaderModule } from './Pages/header/header.module';
import { HeaderComponent } from './Pages/header/header.component';
import { FooterComponent } from './Pages/footer/footer.component';

@NgModule({
    declarations: [AppComponent, HeaderComponent, FooterComponent],
    imports: [BrowserModule, AppRoutingModule, HeaderModule],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
