import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CampaignDefinitionListComponent} from './campaign-definition-list.component';
import {RouterModule, Routes} from "@angular/router";
import {SharedModule} from "../../../modules/shared.module";
import {
  CampaignDefinitionListDetailComponent
} from './campaign-definition-list-detail/campaign-definition-list-detail.component';
import {ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {AngularEditorModule} from "@kolkov/angular-editor";
import {NgxSmartModalModule} from "ngx-smart-modal";
import {AngularMyDatePickerModule} from "angular-mydatepicker";

const routes: Routes = [
  {
    path: '', component: CampaignDefinitionListComponent
  },
  {
    path: 'detail', component: CampaignDefinitionListDetailComponent
  }
]

@NgModule({
  declarations: [
    CampaignDefinitionListComponent,
    CampaignDefinitionListDetailComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule,
    ReactiveFormsModule,
    HttpClientModule,
    AngularEditorModule,
    NgxSmartModalModule.forRoot(),
    AngularMyDatePickerModule,
  ]
})
export class CampaignDefinitionListModule {
}
