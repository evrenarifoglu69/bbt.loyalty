import {Component, OnInit} from '@angular/core';
import {StepService} from "../../services/step.service";
import {TargetDefinitionService} from "../../services/target-definition.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-target-definition',
  templateUrl: './target-definition.component.html',
  styleUrls: ['./target-definition.component.scss']
})
export class TargetDefinitionComponent implements OnInit {
  submitted = false;
  stepData;
  formGroup: FormGroup;

  constructor(private fb: FormBuilder, private stepService: StepService, private targetDefinitionService: TargetDefinitionService, private router: Router, private route: ActivatedRoute) {
    this.stepService.setSteps(this.targetDefinitionService.stepData);
    this.stepService.updateStep(1);
    this.stepData = this.stepService.stepData;
    this.formGroup = this.fb.group({
      name: ['', Validators.required],
      id: ['', Validators.required],
    })
  }

  ngOnInit(): void {
  }

  get f() {
    return this.formGroup.controls;
  }

  continue() {
    this.submitted = true;
    if (this.formGroup.valid) {
      this.router.navigate(['./source'], {relativeTo: this.route})
    }
  }
}
