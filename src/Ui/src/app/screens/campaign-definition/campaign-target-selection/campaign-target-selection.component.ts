import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";
import {StepService} from "../../../services/step.service";

@Component({
  selector: 'app-campaign-target-selection',
  templateUrl: './campaign-target-selection.component.html',
  styleUrls: ['./campaign-target-selection.component.scss']
})
export class CampaignTargetSelectionComponent implements OnInit {

  stepData;

  constructor(private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(3);
    this.stepData = this.stepService.stepData;
  }

  ngOnInit(): void {
  }

}
