import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";

@Component({
  selector: 'app-campaign-rules',
  templateUrl: './campaign-rules.component.html',
  styleUrls: ['./campaign-rules.component.scss']
})
export class CampaignRulesComponent implements OnInit {
  stepData;

  constructor(private campaignDefinitionService: CampaignDefinitionService) {
    this.campaignDefinitionService.updateStep(2);
    this.stepData = this.campaignDefinitionService.stepData;
  }

  ngOnInit(): void {
  }

}
