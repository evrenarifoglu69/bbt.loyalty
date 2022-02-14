import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";
import {StepService} from "../../../services/step.service";

@Component({
  selector: 'app-campaign-finish',
  templateUrl: './campaign-finish.component.html',
  styleUrls: ['./campaign-finish.component.scss']
})
export class CampaignFinishComponent implements OnInit {
  stepData;

  constructor(private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(5);
    this.stepData = this.stepService.stepData;
    this.stepService.finish();
  }

  ngOnInit(): void {
  }

  redirect() {
    window.location.href = '/';
  }
}
