import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-subpanel',
  templateUrl: './subpanel.component.html',
  styleUrls: ['./subpanel.component.css']
})
export class SubpanelComponent implements OnInit {
  @Input()
  public icon: string;

  @Input()
  public title: string;

  @Input()
  public count: number;

  @Input()
  public changeFromLastMonth: number;

  @Input()
  public changeFromLastMonthPercent: number;

  constructor() {

  }

  ngOnInit() {

  }
}
