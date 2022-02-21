import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CampaignDefinitionService {
  stepData = [
    {id: 1, title: 'Kampanya Tanımı', isActive: true, passed: false, route: 'definition'},
    {id: 2, title: 'Kampanya Kuralları', isActive: false, passed: false, route: 'rules'},
    {id: 3, title: 'Hedef Seçimi', isActive: false, passed: false, route: 'target-selection'},
    {id: 4, title: 'Kampanya Kazanımlar', isActive: false, passed: false, route: 'gains'},
  ]

  constructor() {
  }
}
