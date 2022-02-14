import {Injectable} from '@angular/core';
import {Step} from "../models/step.model";

@Injectable({
  providedIn: 'root'
})
export class TargetDefinitionService {
  stepData: Step[] = [
    {id: 1, title: 'Hedef Tanımı', isActive: true, passed: false},
    {id: 2, title: 'Hedef Kaynağı', isActive: false, passed: false},
  ]

  constructor() {
  }
}
