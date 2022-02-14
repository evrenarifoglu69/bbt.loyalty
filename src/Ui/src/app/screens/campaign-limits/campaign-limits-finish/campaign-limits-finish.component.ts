import {Component, OnInit} from '@angular/core';
import {StepService} from "../../../services/step.service";
import {CampaignLimitsService} from "../../../services/campaign-limits.service";

@Component({
  selector: 'app-campaign-limits-finish',
  templateUrl: './campaign-limits-finish.component.html',
  styleUrls: ['./campaign-limits-finish.component.scss']
})
export class CampaignLimitsFinishComponent implements OnInit {
  stepData;

  constructor(private stepService: StepService, private campaignLimitsService: CampaignLimitsService) {
    this.stepService.setSteps(this.campaignLimitsService.stepData);
    this.stepService.updateStep(5);
    this.stepData = this.stepService.stepData;
    this.stepService.finish();
  }

  ngOnInit(): void {
  }

  redirect() {
    window.location.href = '/campaign-limits';
  }
}
