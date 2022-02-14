import {Injectable} from '@angular/core';
import {Step} from "../models/step.model";

@Injectable({
  providedIn: 'root'
})
export class CampaignLimitsService {
  stepData: Step[] = [
    {id: 1, title: 'Kampanya Çatı Limitleri', isActive: true, passed: false},
    {id: 2, title: 'Tamamlandı', isActive: false, passed: false},
  ]

  constructor() {
  }
}
