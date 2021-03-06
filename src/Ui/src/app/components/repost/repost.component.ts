import {Component, Input, OnInit} from '@angular/core';
import {GlobalVariable} from "../../global";

@Component({
  selector: 'app-repost',
  templateUrl: './repost.component.html',
  styleUrls: ['./repost.component.scss']
})
export class RepostComponent implements OnInit {
  @Input('id') id: any;
  link;

  constructor() {
    this.link = GlobalVariable.definition;
  }

  ngOnInit(): void {
  }

}
