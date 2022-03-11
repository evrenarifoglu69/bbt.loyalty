import { Component, OnInit } from '@angular/core';
import {IAngularMyDpOptions} from "angular-mydatepicker";

@Component({
  selector: 'app-target-definition-list',
  templateUrl: './target-definition-list.component.html',
  styleUrls: ['./target-definition-list.component.scss']
})
export class TargetDefinitionListComponent implements OnInit {

  dpOptions: IAngularMyDpOptions = {
    dateRange: false,
    dateFormat: 'dd/mm/yyyy',
  };
  locale: string = 'tr';

  constructor() { }

  ngOnInit(): void {
  }

}
