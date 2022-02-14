import {Component, OnInit} from '@angular/core';
import {StepService} from "../../services/step.service";
import {TargetDefinitionService} from "../../services/target-definition.service";

@Component({
  selector: 'app-target-definition',
  templateUrl: './target-definition.component.html',
  styleUrls: ['./target-definition.component.scss']
})
export class TargetDefinitionComponent implements OnInit {

  stepData;

  constructor(private stepService: StepService, private targetDefinitionService: TargetDefinitionService) {
    this.stepService.setSteps(this.targetDefinitionService.stepData);
    this.stepService.updateStep(1);
    this.stepData = this.stepService.stepData;
  }

  ngOnInit(): void {
  }

}
