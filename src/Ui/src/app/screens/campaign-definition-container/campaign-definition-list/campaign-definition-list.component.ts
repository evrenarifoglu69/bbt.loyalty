import { Component, OnInit } from '@angular/core';
import {IAngularMyDpOptions} from "angular-mydatepicker";

@Component({
  selector: 'app-campaign-definition-list',
  templateUrl: './campaign-definition-list.component.html',
  styleUrls: ['./campaign-definition-list.component.scss']
})
export class CampaignDefinitionListComponent implements OnInit {

  dpOptions: IAngularMyDpOptions = {
    dateRange: false,
    dateFormat: 'dd/mm/yyyy',
  };
  locale: string = 'tr';

  constructor() { }

  ngOnInit(): void {
  }

}
