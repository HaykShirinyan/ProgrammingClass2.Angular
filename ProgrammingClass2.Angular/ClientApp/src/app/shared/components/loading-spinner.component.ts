  import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styleUrls: [
    './loading-spinner.component.css'
  ]
})
export class LoadingSpinnerComponent {
  // Sa kochvum e Input Property. Ays property-i mijocov karox enq drsic parametrer poxancel LoadingSpinnerComponent-in
  // grvum e ayspes` <loading-spinner [isVisible]="true" kam [isVisible]="false"
  @Input()
  public isVisible: boolean;

  @Input()
  public loadingMessage: string = 'Loading...'

  @Input()
  public canHide: boolean;

  @Output()
  public hideClick: EventEmitter<void> = new EventEmitter();

  public onHideClicked(): void {
    // Erb kanchum enq emit function, drsi component-e, vore spasum e (hideClick) event-in
    // texekanum e, vor (hideClick) event-e texi e unecel.
    this.hideClick.emit();
  }
}
