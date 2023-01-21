import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MessageComponent } from "./message.component";

@NgModule({
    imports: [CommonModule],
    declarations: [MessageComponent],
    exports: [MessageComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class MessageModule {}
