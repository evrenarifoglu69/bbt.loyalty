import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../../services/campaign-definition.service";
import {StepService} from "../../../../services/step.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {GlobalVariable} from "../../../../global";

@Component({
  selector: 'app-campaign-rules',
  templateUrl: './campaign-rules.component.html',
  styleUrls: ['./campaign-rules.component.scss']
})
export class CampaignRulesComponent implements OnInit {
  stepData;
  formGroup: FormGroup;
  submitted = false;
  id: any;
  detailId: any;
  repost: boolean = false;
  disabled: boolean = false;

  constructor(private fb: FormBuilder, private stepService: StepService, private campaignDefinitionService: CampaignDefinitionService, private router: Router, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(paramMap => {
      this.id = paramMap.get('id');
      this.detailId = paramMap.get('detailId');
      if (paramMap.get('repost')) {
        this.repost = paramMap.get('repost') === 'true';
      }
      this.disabled = this.id && !this.repost;
    });
    this.stepService.setSteps(this.campaignDefinitionService.stepData);
    this.stepService.updateStep(2);
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
      involvedType: [{value: '', disabled: this.disabled}, Validators.required],
      identityNo: [{value: '', disabled: this.disabled}, [Validators.required, Validators.minLength(11)]],
      businessLine: [{value: '', disabled: true}],
      branch: [{value: '', disabled: true}],
      customerType: [{value: '', disabled: true}],
      campaignStartPeriod: [{value: '', disabled: this.disabled}, Validators.required]
    });
    if (this.id) {
      this.stepService.finish();
      this.formGroup.patchValue({
        involvedType: 2,
        identityNo: 'belge.xml',
        businessLine: 1,
        branch: 1,
        customerType: '',
        campaignStartPeriod: 1
      })
    }
  }

  ngOnInit(): void {
  }

  get f() {
    return this.formGroup.controls;
  }

  involvedTypeChange() {
    const bLine = this.formGroup.get('businessLine');
    const branch = this.formGroup.get('branch');
    const customerType = this.formGroup.get('customerType');
    const involvedType = this.formGroup.get('involvedType');
    bLine?.setValue('');
    branch?.setValue('');
    customerType?.setValue('');
    if (involvedType?.value == 3) {
      bLine?.setValidators(Validators.required);
      bLine?.enable();
    } else {
      bLine?.clearValidators();
      bLine?.disable();
    }
    if (involvedType?.value == 4) {
      branch?.setValidators(Validators.required);
      branch?.enable();
    } else {
      branch?.clearValidators();
      branch?.disable();
    }
    if (involvedType?.value == 5) {
      customerType?.setValidators(Validators.required);
      customerType?.enable();
    } else {
      customerType?.clearValidators();
      customerType?.disable();
    }
  }

  continue() {
    this.submitted = true;
    if (this.formGroup.valid) {
      this.detailId = this.detailId ? this.detailId : 1;
      this.router.navigate([GlobalVariable.target, this.detailId], {relativeTo: this.route});
    }
  }

  fileSelected(e: Event) {
    const element = e.currentTarget as HTMLInputElement;
    let fileList: FileList | null = element.files;
    if (fileList!.length > 0) {
      this.formGroup.patchValue({
        identityNo: fileList && fileList[0].name
      });
    } else {
      this.formGroup.patchValue({
        identityNo: ''
      });
    }
  }
}
