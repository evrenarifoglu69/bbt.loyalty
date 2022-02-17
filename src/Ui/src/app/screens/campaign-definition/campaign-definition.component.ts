import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../services/campaign-definition.service";
import {StepService} from "../../services/step.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {IAngularMyDpOptions} from 'angular-mydatepicker';

@Component({
  selector: 'app-campaign-definition',
  templateUrl: './campaign-definition.component.html',
  styleUrls: ['./campaign-definition.component.scss']
})
export class CampaignDefinitionComponent implements OnInit {
  stepData;
  formGroup: FormGroup;
  submitted = false;
  dpOptions: IAngularMyDpOptions = {
    dateRange: false,
    dateFormat: 'dd.mm.yyyy',
  };
  locale: string = 'tr';

  constructor(private fb: FormBuilder, private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService, private router: Router, private route: ActivatedRoute) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(1);
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
      activePassive: '',
      combined: '',
      contract: '',
      contractId: '',
      campaignName: ['', Validators.required],
      campaignCode: '15162516521',
      descriptionTr: '',
      descriptionEn: '',
      titleTr: '',
      titleEn: '',
      campaignDetailTr: '',
      campaignDetailEn: '',
      htmlSummaryTr: '',
      htmlSummaryEn: '',
      htmlDescTr: '',
      htmlDescEn: '',
      htmlDetailTr: '',
      htmlDetailEn: '',
      startDate: [null, Validators.required],
      endDate: [null, Validators.required],
      campaignListImage: ['', Validators.required],
      campaignDetailImage: ['', Validators.required],
      order: ['', Validators.required],
      maxUser: '',
      sector: ['', Validators.required],
      view: ['', Validators.required],
      action: ['', Validators.required],
    });
  }

  ngOnInit(): void {
  }

  get f() {
    return this.formGroup.controls;
  }

  combinedChanged() {
    if (this.formGroup.get('combined')?.value) {
      this.f.order.clearValidators();
      this.f.order.updateValueAndValidity();
    } else {
      this.f.order.setValidators(Validators.required);
      this.f.order.updateValueAndValidity();
    }
  }

  continue() {
    this.submitted = true;
    if (this.formGroup.valid) {
      this.router.navigate(['./rules'], {relativeTo: this.route});
    }
  }
}
