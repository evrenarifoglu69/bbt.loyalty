import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CampaignDefinitionComponent} from "./campaign-definition.component";
import {SharedModule} from "../../modules/shared.module";
import {RouterModule, Routes} from "@angular/router";
import { CampaignRulesComponent } from './campaign-rules/campaign-rules.component';
import { CampaignTargetSelectionComponent } from './campaign-target-selection/campaign-target-selection.component';
import { CampaignGainsComponent } from './campaign-gains/campaign-gains.component';
import { CampaignFinishComponent } from './campaign-finish/campaign-finish.component';
import {ReactiveFormsModule} from "@angular/forms";

const routes: Routes = [
  {path: '', component: CampaignDefinitionComponent},
  {path: 'rules', component: CampaignRulesComponent},
  {path: 'target-selection', component: CampaignTargetSelectionComponent},
  {path: 'gains', component: CampaignGainsComponent},
  {path: 'finish', component: CampaignFinishComponent},
]

@NgModule({
  declarations: [
    CampaignDefinitionComponent,
    CampaignRulesComponent,
    CampaignTargetSelectionComponent,
    CampaignGainsComponent,
    CampaignFinishComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule
  ]
})
export class CampaignDefinitionModule {
}
