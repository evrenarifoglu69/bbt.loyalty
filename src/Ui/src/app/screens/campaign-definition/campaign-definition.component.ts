import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../services/campaign-definition.service";

@Component({
  selector: 'app-campaign-definition',
  templateUrl: './campaign-definition.component.html',
  styleUrls: ['./campaign-definition.component.scss']
})
export class CampaignDefinitionComponent implements OnInit {
  stepData;

  constructor(private campaignDefinitionService: CampaignDefinitionService) {
    this.campaignDefinitionService.updateStep(1);
    this.stepData = this.campaignDefinitionService.stepData;
  }

  ngOnInit(): void {
  }

}
