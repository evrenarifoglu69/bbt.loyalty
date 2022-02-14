import {Component, OnInit} from '@angular/core';
import {StepService} from "../../services/step.service";
import {CampaignLimitsService} from "../../services/campaign-limits.service";

@Component({
  selector: 'app-campaign-limits',
  templateUrl: './campaign-limits.component.html',
  styleUrls: ['./campaign-limits.component.scss']
})
export class CampaignLimitsComponent implements OnInit {
  stepData;

  constructor(private stepService: StepService, private campaignLimitsService: CampaignLimitsService) {
    this.stepService.setSteps(this.campaignLimitsService.stepData);
    this.stepService.updateStep(1);
    this.stepData = this.stepService.stepData;
  }

  ngOnInit(): void {
  }

}
