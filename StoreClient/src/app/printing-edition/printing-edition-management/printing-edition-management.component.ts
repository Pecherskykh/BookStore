import { Component, OnInit } from '@angular/core';
import {PrintingEditionService} from 'src/app/shared/services/printing-edition-service';
import {PrintingEditionModelItem} from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';

@Component({
  selector: 'app-printing-edition-management',
  templateUrl: './printing-edition-management.component.html',
  styleUrls: ['./printing-edition-management.component.css'],
  providers: [PrintingEditionService]
})

export class PrintingEditionManagementComponent implements OnInit {

  constructor(private printingEditionService: PrintingEditionService) { }

  items: Array<PrintingEditionModelItem>;

  GetPrintingEditions() {
    this.printingEditionService.getData().subscribe(data => {
      this.items = data.items;
  });
}

  ngOnInit() {
  }

}
