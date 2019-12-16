import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { CreateUpdate } from 'src/app/shared/enums/create-update';
import { AuthorModelItem } from 'src/app/shared/models/Authors/author-model-item';
import { FormControl } from '@angular/forms';
import { Currencys } from 'src/app/shared/enums/currencys';
import { AuthorModel } from 'src/app/shared/models/Authors/author-model';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { AuthorService } from 'src/app/shared/services/author-service';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';

@Component({
  selector: 'app-printing-edition-dialog',
  templateUrl: './printing-edition-dialog.component.html',
  styleUrls: ['./printing-edition-dialog.component.css'],
  providers: [AuthorService, PrintingEditionService]
})
export class PrintingEditionDialogComponent implements OnInit {

  items: Array<AuthorModelItem>;
  title = new FormControl(this.data.printingEditionModelItem.title); //todo init on constructor
  description = new FormControl(this.data.printingEditionModelItem.description);
  authors = new FormControl();
  productType = new FormControl(TypePrintingEdition[this.data.printingEditionModelItem.productType]);
  price = new FormControl(this.data.printingEditionModelItem.price);
  currencys: Array<string>;
  currency: FormControl; //todo use FormGroup

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private authorService: AuthorService,
    private printingEditionService: PrintingEditionService
    ) {
    this.currencys = [
      Currencys[Currencys.AUD],
      Currencys[Currencys.BYN],
      Currencys[Currencys.EUR],
      Currencys[Currencys.GBP],
      Currencys[Currencys.PLN],
      Currencys[Currencys.UAH],
      Currencys[Currencys.USD] //todo use const
    ];
    this.currency = new FormControl('');
  }

  ngOnInit() {
    this.authorService.getAll().subscribe((data: AuthorModel) => {
      this.items = data.items;
      if (this.data.createUpdate === CreateUpdate.Update) {
        this.authors = new FormControl(this.selectedAuthors());
      }
  });
  }
  event() {
    if (this.data.createUpdate === CreateUpdate.Create) {
      this.create();
    }

    if (this.data.createUpdate === CreateUpdate.Update) {
      this.update();
    }
  }

  create() {
    let printingEditionModelItem = new PrintingEditionModelItem();

    let authorModel = new AuthorModel();
    authorModel.items = this.authors.value;
    printingEditionModelItem.authors = authorModel;
    printingEditionModelItem.title = this.title.value;
    printingEditionModelItem.description = this.description.value;
    printingEditionModelItem.price = parseFloat(this.price.value);

    //todo replace to private method
    if (this.productType.value === 'book') { //todo use enums
      printingEditionModelItem.productType = TypePrintingEdition.book;
    }
    if (this.productType.value === 'magazine') {
      printingEditionModelItem.productType = TypePrintingEdition.magazine;
    }
    if (this.productType.value === 'newspaper') {
      printingEditionModelItem.productType = TypePrintingEdition.newspaper;
    }

    printingEditionModelItem.currencys = Currencys[this.currency.value as string]; //todo

    this.printingEditionService.create(printingEditionModelItem).subscribe();
  }

  selectedAuthors() {
    let selected = new Array<AuthorModelItem>();
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.data.printingEditionModelItem.authors.items.length; i++) {
      // tslint:disable-next-line: prefer-for-of
      for (let j = 0; j < this.items.length; j++) {
        if (this.data.printingEditionModelItem.authors.items[i].id === this.items[j].id) {
          selected.push(this.items[j]);
        }
      }
    }
    return selected;
  }

  update() {
    this.data.printingEditionModelItem.title = this.title.value;
    this.data.printingEditionModelItem.description = this.description.value;
    this.data.printingEditionModelItem.productType = TypePrintingEdition[this.productType.value];
    this.data.printingEditionModelItem.price = parseFloat(this.price.value);
    this.data.printingEditionModelItem.currencys = Currencys[this.currency.value];
    this.data.printingEditionModelItem.authors.items = this.authors.value;
    this.printingEditionService.update(this.data.printingEditionModelItem).subscribe();
  }
}
