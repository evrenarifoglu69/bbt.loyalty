import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";

@Component({
  selector: 'app-campaign-finish',
  templateUrl: './campaign-finish.component.html',
  styleUrls: ['./campaign-finish.component.scss']
})
export class CampaignFinishComponent implements OnInit {
  stepData;

  constructor(private campaignDefinitionService: CampaignDefinitionService) {
    this.campaignDefinitionService.updateStep(5);
    this.stepData = this.campaignDefinitionService.stepData;
    this.campaignDefinitionService.finish();
  }

  ngOnInit(): void {
  }

  redirect() {
    window.location.href = '/';
  }
}
