import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {IAngularMyDpOptions} from "angular-mydatepicker";
import {StepService} from "../../../../services/step.service";
import {CampaignDefinitionService} from "../../../../services/campaign-definition.service";
import {ActivatedRoute, Router} from "@angular/router";
import {AngularEditorConfig} from "@kolkov/angular-editor";

@Component({
  selector: 'app-campaign-definition-list-detail',
  templateUrl: './campaign-definition-list-detail.component.html',
  styleUrls: ['./campaign-definition-list-detail.component.scss']
})
export class CampaignDefinitionListDetailComponent implements OnInit {

  stepData;
  formGroup: FormGroup;
  submitted = false;
  dpOptions: IAngularMyDpOptions = {
    dateRange: false,
    dateFormat: 'dd.mm.yyyy',
  };
  locale: string = 'tr';
  editorConfig: AngularEditorConfig = {
    editable: false
  }

  constructor(private fb: FormBuilder, private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService) {
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(1);
    this.stepService.finish();
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
      activePassive: [{value: true, disabled: true}],
      combined: [{value: false, disabled: true}],
      contract: [{value: false, disabled: true}],
      contractId: '',
      campaignName: [{value: 'Kampanya 1', disabled: true}, Validators.required],
      campaignCode: '15162516521',
      titleTr: [{value: 'Kampanya Başlık', disabled: true}],
      titleEn: [{value: 'Kampanya Başlık', disabled: true}],
      descriptionTr: [{value: 'Kampanya Açıklama', disabled: true}],
      descriptionEn: [{value: 'Kampanya Açıklama', disabled: true}],
      summaryTr: [{value: 'Lorem Ipsum', disabled: true}],
      summaryEn: [{value: 'Lorem Ipsum', disabled: true}],
      descTr: [{value: 'Lorem Ipsum', disabled: true}],
      descEn: [{value: 'Lorem Ipsum', disabled: true}],
      detailTr: [{value: 'Lorem Ipsum', disabled: true}],
      detailEn: [{value: 'Lorem Ipsum', disabled: true}],
      startDate: [{value: {isRange: false, singleDate: {jsDate: new Date('01.01.2022')}}, disabled: true}, Validators.required],
      endDate: [{value: {isRange: false, singleDate: {jsDate: new Date('01.03.2022')}}, disabled: true}, Validators.required],
      campaignListImage: [{value: '', disabled: true}, Validators.required],
      campaignDetailImage: [{value: '', disabled: true}, Validators.required],
      order: [{value: '', disabled: true}, Validators.required],
      maxUser: [{value: '1000', disabled: true}],
      programType: [{value: 1, disabled: true}],
      sector: [{value: 1, disabled: true}, Validators.required],
      view: [{value: 1, disabled: true}, Validators.required],
      action: [{value: 1, disabled: true}, Validators.required],
    });
  }

  ngOnInit(): void {
  }

  get f() {
    return this.formGroup.controls;
  }

}
