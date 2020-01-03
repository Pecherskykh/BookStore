import { Component, OnInit } from '@angular/core';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { FormControl } from '@angular/forms';
import { PrintingEditionsFilterModel } from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { SortingDirection } from 'src/app/shared/enums/sorting-direction';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { PrintingEditionSortType } from 'src/app/shared/enums/printing-edition-sort-type';
import { PageEvent } from '@angular/material';
import { Currencys } from 'src/app/shared/enums/currencys';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
  providers: [PrintingEditionService]
})
export class HomePageComponent implements OnInit {


  currencys: Array<string>;
  currency: FormControl;
  sortBy: FormControl;
  typePrintingEditionItems: string[];
  typePrintingEdition: FormControl;
  items: Array<PrintingEditionModelItem>;
  searchByName: FormControl;
  minPrice: FormControl;
  maxPrice: FormControl;
  printingEditionsFilterModel: PrintingEditionsFilterModel; //todo get default from const

  countPrintingEditions: number;
  pageIndex: number;

  constructor(private printingEditionService: PrintingEditionService) {
    this.printingEditionsFilterModel = new PrintingEditionsFilterModel();
    this.printingEditionsFilterModel.currency = Currencys.USD;
    this.printingEditionsFilterModel.MinPrice = 0;
    this.printingEditionsFilterModel.MaxPrice = 1000;
    this.printingEditionsFilterModel.SortType = PrintingEditionSortType.id;
    this.printingEditionsFilterModel.pageCount = 0;
    this.printingEditionsFilterModel.pageSize = 6;
    this.printingEditionsFilterModel.SortType = PrintingEditionSortType.price;
    this.printingEditionsFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.printingEditionsFilterModel.Categories =
    [
      TypePrintingEdition.book,
      TypePrintingEdition.magazine,
      TypePrintingEdition.newspaper
    ];
    this.typePrintingEditionItems = ['book', 'magazine', 'newspaper'];
    this.typePrintingEdition = new FormControl(this.typePrintingEditionItems);
    this.minPrice = new FormControl(0);
    this.maxPrice = new FormControl(1000);
    this.sortBy = new FormControl('book');
    this.searchByName = new FormControl();
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

  private GetPrintingEditions() { //todo return type
    this.printingEditionService.getData(this.printingEditionsFilterModel).subscribe(data => {

      //todo data -> add type, check errors (use Base functions)
      this.countPrintingEditions = data.countPrintingEditions;
      this.items = data.items;
  });
  }

  FilterPrintingEditions() {

    debugger;
    this.pageIndex = 0;

    this.printingEditionsFilterModel.pageCount = 0;

    this.printingEditionsFilterModel.searchString = this.searchByName.value;
    this.printingEditionsFilterModel.MinPrice = Number.parseFloat(this.minPrice.value);
    this.printingEditionsFilterModel.MaxPrice = Number.parseFloat(this.maxPrice.value);
    this.printingEditionsFilterModel.Categories = new Array<TypePrintingEdition>();

    this.typePrintingEdition.value.forEach((element: string) => {
      this.printingEditionsFilterModel.Categories.push(TypePrintingEdition[element]);
    });
    this.GetPrintingEditions();
  }

  selectCurrency() {
    this.printingEditionsFilterModel.currency = Currencys[this.currency.value];
    this.GetPrintingEditions();
  }

  sortData() {

    if (this.sortBy.value === 'asc') {
      this.printingEditionsFilterModel.sortingDirection = SortingDirection.lowToHigh;
    }

    if (this.sortBy.value === 'desc') {
      this.printingEditionsFilterModel.sortingDirection = SortingDirection.highToLow;
    }

    this.GetPrintingEditions();
  }

  getServerData(event: PageEvent) {
    this.pageIndex = event.pageIndex;

    this.printingEditionsFilterModel.pageSize = event.pageSize;
    this.printingEditionsFilterModel.pageCount = this.pageIndex;

    this.GetPrintingEditions();
  }

  rout(item: PrintingEditionModelItem) {
    location.href = `http://localhost:4200/printing-edition/book-details/${item.id}`;
  }

  ngOnInit() {
    this.GetPrintingEditions();
  }

}
