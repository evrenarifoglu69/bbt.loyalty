import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";
import {StepService} from "../../../services/step.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-campaign-gains',
  templateUrl: './campaign-gains.component.html',
  styleUrls: ['./campaign-gains.component.scss']
})
export class CampaignGainsComponent implements OnInit {

  stepData;
  showForm = false;
  selectedText = '';
  formGroup: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder, private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(4);
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
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

  closePanel() {
    this.showForm = false;
  }

  allChanged(e: any, title: string) {
    this.selectedText = title;
    this.showForm = true;
  }

  save() {
    this.submitted = true;
    if (this.formGroup.valid) {
      this.showForm = false;
    }
  }
}
