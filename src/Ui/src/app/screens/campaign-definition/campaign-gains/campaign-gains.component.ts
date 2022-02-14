import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";
import {StepService} from "../../../services/step.service";

@Component({
  selector: 'app-campaign-gains',
  templateUrl: './campaign-gains.component.html',
  styleUrls: ['./campaign-gains.component.scss']
})
export class CampaignGainsComponent implements OnInit {

  stepData;
  showForm = false;
  selectedText = '';
  alwaysChecked = true;

  constructor(private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(4);
    this.stepData = this.stepService.stepData;
  }

  ngOnInit(): void {
  }

  closePanel() {
    this.showForm = false;
    setTimeout(() => {
      this.alwaysChecked = true;
    }, 100);
  }

  allChanged(e: any, title: string) {
    this.selectedText = title;
    this.showForm = true;
  }
}
