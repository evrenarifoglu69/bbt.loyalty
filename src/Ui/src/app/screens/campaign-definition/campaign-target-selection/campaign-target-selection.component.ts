import { Component, OnInit } from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";

@Component({
  selector: 'app-campaign-target-selection',
  templateUrl: './campaign-target-selection.component.html',
  styleUrls: ['./campaign-target-selection.component.scss']
})
export class CampaignTargetSelectionComponent implements OnInit {

  stepData;

  constructor(private campaignDefinitionService: CampaignDefinitionService) {
    this.campaignDefinitionService.updateStep(3);
    this.stepData = this.campaignDefinitionService.stepData;
  }

  ngOnInit(): void {
  }

}
