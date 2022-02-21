import {Component, OnInit} from '@angular/core';
import {CampaignDefinitionService} from "../../../../services/campaign-definition.service";
import {StepService} from "../../../../services/step.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NgxSmartModalService} from "ngx-smart-modal";
import {ActivatedRoute, Router} from "@angular/router";
import {GlobalVariable} from "../../../../global";

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
  id: any;
  detailId: any;
  repost: boolean = false;
  disabled: boolean = false;

  constructor(private modalService: NgxSmartModalService,
              private fb: FormBuilder,
              private stepService: StepService,
              private campaignDefinitionService: CampaignDefinitionService,
              private router: Router, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(paramMap => {
      this.id = paramMap.get('id');
      this.detailId = paramMap.get('detailId');
      if (paramMap.get('repost')) {
        this.repost = paramMap.get('repost') === 'true';
      }
      this.disabled = this.id && !this.repost;
    });
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
    if (this.id) {
      this.stepService.finish();
      this.switchFormGroup.all = true;
    }
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

  continue() {
    this.detailId = this.detailId ? this.detailId : 1;
    this.router.navigate([GlobalVariable.finish, this.detailId], {relativeTo: this.route});
  }
}
