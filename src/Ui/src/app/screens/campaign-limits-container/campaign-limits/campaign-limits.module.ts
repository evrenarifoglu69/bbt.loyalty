import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CampaignLimitsComponent} from "./campaign-limits.component";
import {SharedModule} from "../../../modules/shared.module";
import {RouterModule, Routes} from "@angular/router";
import {CampaignLimitsFinishComponent} from './campaign-limits-finish/campaign-limits-finish.component';
import {ReactiveFormsModule} from "@angular/forms";

const routes: Routes = [
  {path: '', component: CampaignLimitsComponent},
  {path: 'finish', component: CampaignLimitsFinishComponent},
]

@NgModule({
  declarations: [
    CampaignLimitsComponent,
    CampaignLimitsFinishComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule
  ]
})

export class CampaignLimitsModule {
}
