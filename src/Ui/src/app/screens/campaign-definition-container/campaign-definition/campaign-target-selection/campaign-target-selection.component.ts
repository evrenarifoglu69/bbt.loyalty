import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../../services/campaign-definition.service";
import {StepService} from "../../../../services/step.service";
import {ActivatedRoute, Router} from "@angular/router";
import {GlobalVariable} from "../../../../global";

@Component({
  selector: 'app-campaign-target-selection',
  templateUrl: './campaign-target-selection.component.html',
  styleUrls: ['./campaign-target-selection.component.scss']
})
export class CampaignTargetSelectionComponent implements OnInit {

  stepData;
  id: any;
  detailId: any;
  repost: boolean = false;
  disabled: boolean = false;

  constructor(private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService, private router: Router, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(paramMap => {
      this.id = paramMap.get('id');
      this.detailId = paramMap.get('detailId');
      if (paramMap.get('repost')) {
        this.repost = paramMap.get('repost') === 'true';
      }
      this.disabled = this.id && !this.repost;
    });
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(3);
    this.stepData = this.stepService.stepData;
    if (this.id) {
      this.stepService.finish();
    }
  }

  ngOnInit(): void {
  }

  continue() {
    this.detailId = this.detailId ? this.detailId : 1;
    this.router.navigate([GlobalVariable.gains, this.detailId], {relativeTo: this.route});
  }
}
