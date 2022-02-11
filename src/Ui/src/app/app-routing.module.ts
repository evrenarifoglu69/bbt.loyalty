import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from "./screens/login/login.component";
import {DefaultLayoutComponent} from "./layouts/default-layout/default-layout.component";

const routes: Routes = [
  {path: '', redirectTo: 'campaign-definition', pathMatch: 'full'},
  {
    path: '', component: DefaultLayoutComponent,
    children: [
      {
        path: 'campaign-definition',
        loadChildren: () => import('./screens/campaign-definition/campaign-definition.module').then(m => m.CampaignDefinitionModule)
      }
    ]
  },
  {
    path: 'login', component: LoginComponent
  },
  {path: '**', redirectTo: 'campaign-definition'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
