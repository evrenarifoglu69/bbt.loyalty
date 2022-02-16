import {NgModule} from '@angular/core';
import {MainContentComponent} from "../components/main-content/main-content.component";
import {CommonModule, DecimalPipe} from "@angular/common";
import {BackButtonDirective} from "../directives/back-button.directive";
import {RouterModule} from "@angular/router";
import {OnlyNumberDirective} from "../directives/only-number.directive";
import {StepComponent} from "../components/step/step.component";
import {UiSwitchModule} from 'ngx-ui-switch';
import {FinishComponent} from "../components/finish/finish.component";
import {TurkishLiraDirective} from "../directives/turkish-lira.directive";

@NgModule({
  declarations: [
    MainContentComponent,
    BackButtonDirective,
    OnlyNumberDirective,
    StepComponent,
    FinishComponent,
    TurkishLiraDirective
  ],
  imports: [CommonModule, RouterModule, UiSwitchModule],
  exports: [
    MainContentComponent,
    BackButtonDirective,
    OnlyNumberDirective,
    StepComponent,
    UiSwitchModule,
    FinishComponent,
    TurkishLiraDirective
  ],
  providers: [DecimalPipe]
})
export class SharedModule {
}
