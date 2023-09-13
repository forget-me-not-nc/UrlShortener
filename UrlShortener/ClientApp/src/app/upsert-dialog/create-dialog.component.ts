import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Url } from '../models/url.model';
import { CreateUrlModel } from '../models/create.url.model';
import { UrlService } from '../services/url.service';

@Component({
  selector: 'app-create-dialog',
  templateUrl: './create-dialog.component.html',
  styleUrls: ['./create-dialog.component.css'],
  providers: [],
})
export class CreateDialogComponent {
  @ViewChild('closeModal') closeModal: ElementRef

  url: CreateUrlModel = {
    baseUrl: "",
    description: "",
  };

  errorMsg: string = "";

  @Input() isCreate: boolean;
  @Input() id: number;
  
  @Output() updateListEvent = new EventEmitter<Url>();
  constructor(private urlService: UrlService) {} 

  cancel() {
    this.url.baseUrl = "";
    this.url.description = "";
    this.errorMsg = "";
  }

  create() {
    this.urlService.create(this.url).subscribe((resp) => {
      this.updateListEvent.emit(resp);
      this.closeModal.nativeElement.click();
      this.errorMsg = "";
    }, (error) => {
      this.errorMsg = error.error;
    });
  }
}
