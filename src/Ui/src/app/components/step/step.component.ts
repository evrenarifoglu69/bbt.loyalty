import {Component, Input, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../services/campaign-definition.service";

@Component({
  selector: 'app-step',
  templateUrl: './step.component.html',
  styleUrls: ['./step.component.scss']
})
export class StepComponent implements OnInit {
  @Input('data') data: any;
  isFinished;

  constructor(private campaignDefinitionService: CampaignDefinitionService) {
    this.isFinished = this.campaignDefinitionService.isFinished;
  }

  ngOnInit(): void {
  }

}
