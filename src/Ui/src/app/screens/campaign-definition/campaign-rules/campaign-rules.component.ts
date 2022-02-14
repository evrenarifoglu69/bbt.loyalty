import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";
import {StepService} from "../../../services/step.service";

@Component({
  selector: 'app-campaign-rules',
  templateUrl: './campaign-rules.component.html',
  styleUrls: ['./campaign-rules.component.scss']
})
export class CampaignRulesComponent implements OnInit {
  stepData;

  constructor(private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(2);
    this.stepData = this.stepService.stepData;
  }

  ngOnInit(): void {
  }

}
