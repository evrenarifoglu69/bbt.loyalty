import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../services/campaign-definition.service";
import {StepService} from "../../../services/step.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {IAngularMyDpOptions} from 'angular-mydatepicker';
import {AngularEditorConfig} from "@kolkov/angular-editor";

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
  id: any;
  repost: boolean = false;
  disabled: boolean = false;
  editorConfig: AngularEditorConfig = {
    editable: true
  }

  constructor(private fb: FormBuilder, private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService, private router: Router, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(paramMap => {
      this.id = paramMap.get('id');
      if (paramMap.get('repost')) {
        this.repost = paramMap.get('repost') === 'true';
      }
      this.disabled = this.id && !this.repost;
    });
    this.editorConfig.editable = !this.disabled;
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(1);
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
      activePassive: [{value: '', disabled: this.disabled}],
      combined: [{value: '', disabled: this.disabled}],
      contract: [{value: '', disabled: this.disabled}],
      contractId: [{value: '', disabled: this.disabled}],
      campaignName: [{value: '', disabled: this.disabled}, Validators.required],
      campaignCode: [{value: '15162516521', disabled: this.disabled}],
      descriptionTr: [{value: '', disabled: this.disabled}],
      descriptionEn: [{value: '', disabled: this.disabled}],
      titleTr: [{value: '', disabled: this.disabled}],
      titleEn: [{value: '', disabled: this.disabled}],
      summaryTr: [{value: '', disabled: this.disabled}],
      summaryEn: [{value: '', disabled: this.disabled}],
      descTr: [{value: '', disabled: this.disabled}],
      descEn: [{value: '', disabled: this.disabled}],
      detailTr: [{value: '', disabled: this.disabled}],
      detailEn: [{value: '', disabled: this.disabled}],
      startDate: [{value: null, disabled: this.disabled}, Validators.required],
      endDate: [{value: '', disabled: this.disabled}, Validators.required],
      campaignListImage: [{value: '', disabled: this.disabled}, Validators.required],
      campaignDetailImage: [{value: '', disabled: this.disabled}, Validators.required],
      order: [{value: '', disabled: this.disabled}, Validators.required],
      maxUser: [{value: '', disabled: this.disabled}],
      programType: [{value: '', disabled: this.disabled}],
      sector: [{value: '', disabled: this.disabled}, Validators.required],
      view: [{value: '', disabled: this.disabled}, Validators.required],
      action: [{value: '', disabled: this.disabled}, Validators.required],
    });
    if (this.id) {
      this.stepService.finish();
      this.formGroup.patchValue({
        activePassive: true,
        combined: false,
        contract: false,
        contractId: '',
        campaignName: 'Kampanya 1',
        campaignCode: '15162516521',
        titleTr: 'Kampanya Başlık',
        titleEn: 'Kampanya Başlık',
        descriptionTr: 'Kampanya Açıklama',
        descriptionEn: 'Kampanya Açıklama',
        summaryTr: 'Lorem Ipsum',
        summaryEn: 'Lorem Ipsum',
        descTr: 'Lorem Ipsum',
        descEn: 'Lorem Ipsum',
        detailTr: 'Lorem Ipsum',
        detailEn: 'Lorem Ipsum',
        startDate: {isRange: false, singleDate: {jsDate: new Date('01.01.2022')}},
        endDate: {isRange: false, singleDate: {jsDate: new Date('01.03.2022')}},
        campaignListImage: '',
        campaignDetailImage: '',
        order: '',
        maxUser: '1000',
        programType: 1,
        sector: 1,
        view: 1,
        action: 1
      })
    }
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
