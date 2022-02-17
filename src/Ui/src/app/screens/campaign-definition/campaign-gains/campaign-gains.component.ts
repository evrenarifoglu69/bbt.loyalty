import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";
import {StepService} from "../../../services/step.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NgxSmartModalService} from "ngx-smart-modal";

@Component({
  selector: 'app-campaign-gains',
  templateUrl: './campaign-gains.component.html',
  styleUrls: ['./campaign-gains.component.scss']
})
export class CampaignGainsComponent implements OnInit {

  stepData;
  formGroup: FormGroup;
  submitted = false;
  selectedText: string = '';
  switchFormGroup = {
    all: false,
    batch: false,
    sms: false,
    dealer: false,
    branch: false,
    other: false,
    tablet: false,
    internet: false,
    web: false,
    ptt: false,
    webDealer: false,
    remote: false,
    webDeposit: false
  };

  constructor(private modalService: NgxSmartModalService, private fb: FormBuilder, private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(4);
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
      choice: 1,
      currency: ['', Validators.required],
      price: '',
      ratio: '',
      maxPrice: '',
      maxBenefit: '',
    });
  }

  ngOnInit(): void {
  }

  get f() {
    return this.formGroup.controls;
  }

  changed(e: any, selectedText: string) {
    if (e) {
      this.selectedText = selectedText;
      this.modalService.open('modal');
    }
  }

  save() {
    this.submitted = true;
    if (this.formGroup.valid) {
      this.modalService.close('modal');
    }
  }
}
