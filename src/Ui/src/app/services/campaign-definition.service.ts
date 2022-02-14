import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CampaignDefinitionService {
  stepData = [
    {id: 1, title: 'Kampanya Tanımı', isActive: true, passed: false},
    {id: 2, title: 'Kampanya Kuralları', isActive: false, passed: false},
    {id: 3, title: 'Hedef Seçimi', isActive: false, passed: false},
    {id: 4, title: 'Kampanya Kazanımlar', isActive: false, passed: false},
  ]

  constructor() {
  }
}
