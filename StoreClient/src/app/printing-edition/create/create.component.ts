import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/shared/services/author-service';
import { AuthorModelItem } from 'src/app/shared/models/Authors/author-model-item';
import { AuthorModel } from 'src/app/shared/models/Authors/author-model';
import { FormControl } from '@angular/forms';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { Currencys } from 'src/app/shared/enums/currencys';
//todo add index.ts files

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers: [AuthorService, PrintingEditionService]
})
export class CreateComponent implements OnInit {

  items: Array<AuthorModelItem>;
  title = new FormControl(''); //todo init on constructor
  description = new FormControl('');
  authors = new FormControl();
  productType = new FormControl('');
  price = new FormControl();
  currencys: Array<string>;
  currency: FormControl; //todo use FormGroup

  constructor(private authorService: AuthorService, private printingEditionService: PrintingEditionService) {
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

  create() { //todo return type
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

  ngOnInit() {
    this.authorService.getAll().subscribe((data: AuthorModel) => {
      this.items = data.items;
  });
  }
}
