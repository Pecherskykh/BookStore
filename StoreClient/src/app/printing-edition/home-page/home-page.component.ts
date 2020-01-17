import { Component, OnInit } from '@angular/core';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { FormControl, FormBuilder } from '@angular/forms';
import { PrintingEditionsFilterModel } from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { SortingDirection } from 'src/app/shared/enums/sorting-direction';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { PrintingEditionSortType } from 'src/app/shared/enums/printing-edition-sort-type';
import { PageEvent, MatDialog } from '@angular/material';
import { Currencys } from 'src/app/shared/enums/currencys';
import { PrintingEditionConstants } from 'src/app/shared/constans/printing-edition-constants';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { PaginationConstants } from 'src/app/shared/constans/pagination-constants';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
  providers: [PrintingEditionService]
})
export class HomePageComponent implements OnInit {

  pageSizeOptions: number[];
  currencys: string[];
  typePrintingEditionItems: string[];
  items: Array<PrintingEditionModelItem>;
  homeForm;
  printingEditionsFilterModel: PrintingEditionsFilterModel; //todo get default from const

  countPrintingEditions: number;
  pageIndex: number;

  constructor(private printingEditionService: PrintingEditionService, private formBuilder: FormBuilder, private dialog: MatDialog) {

    this.pageSizeOptions = PaginationConstants.pageSizeOptions;
    this.printingEditionsFilterModel = new PrintingEditionsFilterModel();
    this.printingEditionsFilterModel.currency = Currencys.USD;
    this.printingEditionsFilterModel.minPrice = BaseConstants.zero;
    this.printingEditionsFilterModel.maxPrice = PrintingEditionConstants.maxPrice;
    this.printingEditionsFilterModel.sortType = PrintingEditionSortType.id;
    this.printingEditionsFilterModel.pageCount = BaseConstants.zero;
    this.printingEditionsFilterModel.pageSize = this.pageSizeOptions[0];
    this.printingEditionsFilterModel.sortType = PrintingEditionSortType.price;
    this.printingEditionsFilterModel.sortingDirection = SortingDirection.asc;
    this.printingEditionsFilterModel.categories =
    [
      TypePrintingEdition.book,
      TypePrintingEdition.magazine,
      TypePrintingEdition.newspaper
    ];
    this.typePrintingEditionItems = PrintingEditionConstants.typePrintingEditionItems;
    this.currencys = PrintingEditionConstants.currencys;

    this.homeForm = this.formBuilder.group({
      currency: Currencys[Currencys.USD],
      sortBy: SortingDirection[SortingDirection.asc],
      typePrintingEdition: new FormControl(this.typePrintingEditionItems),
      searchByName: BaseConstants.stringEmpty,
      minPrice: BaseConstants.zero,
      maxPrice: PrintingEditionConstants.maxPrice
    });
  }

  private getPrintingEditions(): void { //todo return type
    this.printingEditionService.getData(this.printingEditionsFilterModel).subscribe(data => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
        return;
      }
      this.countPrintingEditions = data.countPrintingEditions;
      this.items = data.items;
  });
  }

  filterPrintingEditions() {

    this.pageIndex = 0;

    this.printingEditionsFilterModel.pageCount = 0;

    this.printingEditionsFilterModel.searchString = this.homeForm.value.searchByName;
    this.printingEditionsFilterModel.minPrice = Number.parseFloat(this.homeForm.value.minPrice);
    this.printingEditionsFilterModel.maxPrice = Number.parseFloat(this.homeForm.value.maxPrice);
    this.printingEditionsFilterModel.categories = new Array<TypePrintingEdition>();

    this.homeForm.value.typePrintingEdition.forEach((element: string) => {
      this.printingEditionsFilterModel.categories.push(TypePrintingEdition[element]);
    });
    this.getPrintingEditions();
  }

  selectCurrency() {
    this.printingEditionsFilterModel.currency = Currencys[this.homeForm.value.currency as string];
    this.getPrintingEditions();
  }

  sortData() {

    if (this.homeForm.value.sortBy === SortingDirection[SortingDirection.asc]) {
      this.printingEditionsFilterModel.sortingDirection = SortingDirection.asc;
    }

    if (this.homeForm.value.sortBy === SortingDirection[SortingDirection.desc]) {
      this.printingEditionsFilterModel.sortingDirection = SortingDirection.desc;
    }

    this.getPrintingEditions();
  }

  getServerData(event: PageEvent) {
    this.pageIndex = event.pageIndex;

    this.printingEditionsFilterModel.pageSize = event.pageSize;
    this.printingEditionsFilterModel.pageCount = this.pageIndex;

    this.getPrintingEditions();
  }

  rout(item: PrintingEditionModelItem) {
    this.printingEditionService.printingEdition = item;
    location.href = `http://localhost:4200/printing-edition/book-details/${item.id}`;
  }

  ngOnInit() {
    this.getPrintingEditions();
  }
}
