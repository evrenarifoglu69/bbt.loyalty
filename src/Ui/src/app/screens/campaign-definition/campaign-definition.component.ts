import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../services/campaign-definition.service";
import {StepService} from "../../services/step.service";

@Component({
  selector: 'app-campaign-definition',
  templateUrl: './campaign-definition.component.html',
  styleUrls: ['./campaign-definition.component.scss']
})
export class CampaignDefinitionComponent implements OnInit {
  stepData;

  constructor(private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(1);
    this.stepData = this.stepService.stepData;
  }

  ngOnInit(): void {
  }

}
