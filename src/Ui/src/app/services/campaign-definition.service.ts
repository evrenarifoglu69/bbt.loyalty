import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CampaignDefinitionService {
  isFinished: any;
  stepData = [
    {id: 1, title: 'Kampanya Tanımı', isActive: true, passed: false},
    {id: 2, title: 'Kampanya Kuralları', isActive: false, passed: false},
    {id: 3, title: 'Hedef Seçimi', isActive: false, passed: false},
    {id: 4, title: 'Kampanya Kazanımlar', isActive: false, passed: false},
  ]

  constructor() {
  }

  updateStep(step: number): void {
    this.isFinished = false;
    this.stepData.map(s => {
      s.isActive = false;
      s.passed = false
    });
    const find = this.stepData.find(s => s.id === step);
    if (find) {
      find.isActive = true;
    }
    this.stepData.filter(s => s.id < step).map(s => {
      s.isActive = false;
      s.passed = true
    });
  }

  finish() {
    this.isFinished = true;
  }
}
