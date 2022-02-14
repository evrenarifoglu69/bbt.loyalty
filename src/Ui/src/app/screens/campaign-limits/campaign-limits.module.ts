import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CampaignLimitsComponent} from "./campaign-limits.component";
import {SharedModule} from "../../modules/shared.module";
import {RouterModule, Routes} from "@angular/router";

const routes: Routes = [
  {path: '', component: CampaignLimitsComponent}
]

@NgModule({
  declarations: [
    CampaignLimitsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class CampaignLimitsModule {
}
