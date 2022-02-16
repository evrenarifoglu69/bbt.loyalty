import {Component, OnInit} from '@angular/core';
import {StepService} from "../../../services/step.service";
import {TargetDefinitionService} from "../../../services/target-definition.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-target-source',
  templateUrl: './target-source.component.html',
  styleUrls: ['./target-source.component.scss']
})
export class TargetSourceComponent implements OnInit {
  submitted = false;
  stepData;
  source: any = null;
  formGroup: FormGroup;

  constructor(private fb: FormBuilder, private stepService: StepService, private targetDefinitionService: TargetDefinitionService, private router: Router, private route: ActivatedRoute) {
    this.stepService.setSteps(this.targetDefinitionService.stepData);
    this.stepService.updateStep(2);
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
      source: ['', Validators.required],
      streamName: '',
      totalPrice: '',
      processCount: '',
      triggerTime: '',
      condition: '',
      query: '',
      verificationTime: '',
    });
  }

  ngOnInit(): void {
  }

  get f() {
    return this.formGroup.controls;
  }

  continue() {
    this.submitted = true;
    if (this.formGroup.valid) {
      this.router.navigate(['../finish'], {relativeTo: this.route});
    }
  }

  sourceChanged() {
    if (this.formGroup.get('source')?.value == 1) {
      this.f.streamName.setValidators(Validators.required);
      this.f.totalPrice.setValidators(Validators.required);
      this.f.processCount.setValidators(Validators.required);
      this.f.triggerTime.setValidators(Validators.required);
      this.f.condition.clearValidators();
      this.f.query.clearValidators();
      this.f.verificationTime.clearValidators();
      Object.keys(this.f).forEach(key => {
        this.formGroup.controls[key].updateValueAndValidity();
      });
    } else {
      this.f.streamName.clearValidators();
      this.f.totalPrice.clearValidators();
      this.f.processCount.clearValidators();
      this.f.triggerTime.clearValidators();
      this.f.condition.setValidators(Validators.required);
      this.f.query.setValidators(Validators.required);
      this.f.verificationTime.setValidators(Validators.required);
      Object.keys(this.f).forEach(key => {
        this.formGroup.controls[key].updateValueAndValidity();
      });
    }
  }
}
