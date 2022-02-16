import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {TargetDefinitionComponent} from './target-definition.component';
import {SharedModule} from "../../modules/shared.module";
import {RouterModule, Routes} from "@angular/router";
import {TargetSourceComponent} from './target-source/target-source.component';
import {TargetFinishComponent} from './target-finish/target-finish.component';
import {ReactiveFormsModule} from "@angular/forms";

const routes: Routes = [
  {path: '', component: TargetDefinitionComponent},
  {path: 'source', component: TargetSourceComponent},
  {path: 'finish', component: TargetFinishComponent},
]

@NgModule({
  declarations: [
    TargetDefinitionComponent,
    TargetSourceComponent,
    TargetFinishComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes),
    ReactiveFormsModule
  ]
})
export class TargetDefinitionModule {
}
