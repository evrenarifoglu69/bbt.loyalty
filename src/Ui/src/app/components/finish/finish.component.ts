import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-finish',
  templateUrl: './finish.component.html',
  styleUrls: ['./finish.component.scss']
})
export class FinishComponent implements OnInit {
  @Input('title') title: any;
  @Input('subTitle') subTitle: any;
  @Input('buttonText') buttonText: any;
  @Output() callback: EventEmitter<any> = new EventEmitter();

  constructor() {
  }

  ngOnInit(): void {
  }

  f() {
    this.callback.emit();
  }
}
