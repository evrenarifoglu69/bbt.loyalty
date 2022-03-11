import { Component, OnInit } from '@angular/core';
import {IAngularMyDpOptions} from "angular-mydatepicker";

@Component({
  selector: 'app-campaign-limits-list',
  templateUrl: './campaign-limits-list.component.html',
  styleUrls: ['./campaign-limits-list.component.scss']
})
export class CampaignLimitsListComponent implements OnInit {

  dpOptions: IAngularMyDpOptions = {
    dateRange: false,
    dateFormat: 'dd/mm/yyyy',
  };
  locale: string = 'tr';

  constructor() { }

  ngOnInit(): void {
  }

}
