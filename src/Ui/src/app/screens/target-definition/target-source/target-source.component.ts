import {Component, OnInit} from '@angular/core';
import {StepService} from "../../../services/step.service";
import {TargetDefinitionService} from "../../../services/target-definition.service";

@Component({
  selector: 'app-target-source',
  templateUrl: './target-source.component.html',
  styleUrls: ['./target-source.component.scss']
})
export class TargetSourceComponent implements OnInit {

  stepData;
  source: any = null;

  constructor(private stepService: StepService, private targetDefinitionService: TargetDefinitionService) {
    this.stepService.setSteps(this.targetDefinitionService.stepData);
    this.stepService.updateStep(2);
    this.stepData = this.stepService.stepData;
  }

  ngOnInit(): void {
  }

}
