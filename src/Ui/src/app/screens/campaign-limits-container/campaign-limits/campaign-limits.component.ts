import {Component, OnInit} from '@angular/core';
import {StepService} from "../../../services/step.service";
import {CampaignLimitsService} from "../../../services/campaign-limits.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-campaign-limits',
  templateUrl: './campaign-limits.component.html',
  styleUrls: ['./campaign-limits.component.scss']
})
export class CampaignLimitsComponent implements OnInit {
  stepData;
  formGroup: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder,
              private stepService: StepService,
              private campaignLimitsService: CampaignLimitsService,
              private router: Router,
              private route: ActivatedRoute) {
    this.stepService.setSteps(this.campaignLimitsService.stepData);
    this.stepService.updateStep(1);
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
      campaignName: ['', Validators.required],
      gainFrequency: ['', Validators.required],
      choice: 1,
      currency: ['', Validators.required],
      maxPrice: ''
    });
  }

  get f() {
    return this.formGroup.controls;
  }

  ngOnInit(): void {
  }

  continue() {
    this.submitted = true;
    if (this.formGroup.valid) {
      this.router.navigate(['./finish'], {relativeTo: this.route});
    }
  }
}
