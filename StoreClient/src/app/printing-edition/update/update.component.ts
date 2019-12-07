import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { FormControl } from '@angular/forms';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { Currencys } from 'src/app/shared/enums/currencys';
import { AuthorService } from 'src/app/shared/services/author-service';
import { AuthorModel } from 'src/app/shared/models/Authors/author-model';
import { AuthorModelItem } from 'src/app/shared/models/Authors/author-model-item';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css'],
  providers: [PrintingEditionService, AuthorService]
})
export class UpdateComponent implements OnInit {

  items: Array<AuthorModelItem>;
  title = new FormControl(this.data.title); //todo init on constructor
  description = new FormControl(this.data.description);
  authors: FormControl;
  productType = new FormControl(TypePrintingEdition[this.data.productType]);
  price = new FormControl(this.data.price);
  currencys: Array<string>;
  currency: FormControl; //todo use FormGroup

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private printingService: PrintingEditionService,
    private authorService: AuthorService
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
      this.currency = new FormControl(Currencys[Currencys.USD]);
  }

  save() {
    this.data.title = this.title.value;
    this.data.description = this.description.value;
    this.data.productType = TypePrintingEdition[this.productType.value];
    this.data.price = parseFloat(this.price.value);
    this.data.currencys = Currencys[this.currency.value];
    this.data.authors.items = this.authors.value;
    this.printingService.update(this.data).subscribe();
  }

  selectedAuthors() {
    let selected = new Array<AuthorModelItem>();
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.data.authors.items.length; i++) {
      // tslint:disable-next-line: prefer-for-of
      for (let j = 0; j < this.items.length; j++) {
        if (this.data.authors.items[i].id === this.items[j].id) {
          selected.push(this.items[j]);
        }
      }
    }
    return selected;
  }

  ngOnInit() {
    this.authorService.getAll().subscribe((data: AuthorModel) => {
      this.items = data.items;
      this.authors = new FormControl(this.selectedAuthors());
  });
}
}
