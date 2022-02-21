import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-repost',
  templateUrl: './repost.component.html',
  styleUrls: ['./repost.component.scss']
})
export class RepostComponent implements OnInit {
  @Input('id') id: any;

  constructor() {
  }

  ngOnInit(): void {
  }

}
