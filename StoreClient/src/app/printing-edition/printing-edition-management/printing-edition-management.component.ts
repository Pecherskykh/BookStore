import { Component, OnInit } from '@angular/core';
import {PrintingEditionService} from 'src/app/shared/services/printing-edition-service';
import {PrintingEditionModelItem} from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import {PrintingEditionsFilterModel} from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { FormControl } from '@angular/forms';
import {PrintingEditionSortType} from 'src/app/shared/enums/printing-edition-sort-type';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { MatDialog, PageEvent, MatSort } from '@angular/material';
import { RemoveComponent } from 'src/app/shared/components/remove/remove.component';
import { PrintingEditionDialogComponent } from '../printing-edition-dialog/printing-edition-dialog.component';
import { CreateUpdate } from 'src/app/shared/enums/create-update';
import { Currencys } from 'src/app/shared/enums/currencys';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';

@Component({
  selector: 'app-printing-edition-management',
  templateUrl: './printing-edition-management.component.html',
  styleUrls: ['./printing-edition-management.component.css'],
  providers: [PrintingEditionService]
})

export class PrintingEditionManagementComponent implements OnInit {
  displayedColumns: string[]; //todo use const, init on constr
  typePrintingEditionItems: string[];
  typePrintingEdition: FormControl;
  items: Array<PrintingEditionModelItem>;
  searchByName: FormControl;
  minPrice: FormControl;
  maxPrice: FormControl;
  printingEditionsFilterModel: PrintingEditionsFilterModel; //todo get default from const

  countPrintingEditions: number;
  pageIndex: number;

  constructor(private printingEditionService: PrintingEditionService, public dialog: MatDialog) {
    this.printingEditionsFilterModel = new PrintingEditionsFilterModel();
    this.printingEditionsFilterModel.MinPrice = 0;
    this.printingEditionsFilterModel.MaxPrice = 1000;
    this.printingEditionsFilterModel.SortType = PrintingEditionSortType.id;
    this.printingEditionsFilterModel.pageCount = 0;
    this.printingEditionsFilterModel.pageSize = 10;
    this.printingEditionsFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.printingEditionsFilterModel.currency = Currencys.USD;
    this.printingEditionsFilterModel.Categories =
    [
      TypePrintingEdition.book,
      TypePrintingEdition.magazine,
      TypePrintingEdition.newspaper
    ];

    this.displayedColumns = DisplayedColumnsConstans.printingEditions;
    this.typePrintingEditionItems = ['book', 'magazine', 'newspaper'];

    this.typePrintingEdition = new FormControl(this.typePrintingEditionItems);
    this.searchByName = new FormControl('');
    this.minPrice = new FormControl(0);
    this.maxPrice = new FormControl(1000);
  }

  ngOnInit() {
    this.GetPrintingEditions();
  }

  create() {
    let element = new PrintingEditionModelItem();
    let dialogRef = this.dialog.open(PrintingEditionDialogComponent, {data: {pageName: 'Add new Product', buttonName: 'Add',
    createUpdate: CreateUpdate.Create, printingEditionModelItem: element}}).
    afterClosed().subscribe(() => this.GetPrintingEditions());
  }

  remove(element: PrintingEditionModelItem) {
    let dialogRef = this.dialog.open(RemoveComponent, {data: {pageName: 'printing edition', name: element.title}})
    .afterClosed().subscribe(data => {
      if (data) {
      this.printingEditionService.remove(element).subscribe();
      this.GetPrintingEditions();
      }
    });
  }

  edit(element: PrintingEditionModelItem) {
    let dialogRef = this.dialog.open(PrintingEditionDialogComponent, {data: {pageName:
      'Edit Product - ' + element.title, buttonName: 'Save',
    createUpdate: CreateUpdate.Update, printingEditionModelItem: element}}).
    afterClosed().subscribe(() => this.GetPrintingEditions());
  }

  private GetPrintingEditions() { //todo return type
    this.printingEditionService.getData(this.printingEditionsFilterModel).subscribe(data => {
      //todo data -> add type, check errors (use Base functions)
      this.countPrintingEditions = data.countPrintingEditions;
      this.items = data.items;
  });
}

  getServerData(event: PageEvent) {
    this.pageIndex = event.pageIndex;

    this.printingEditionsFilterModel.pageSize = event.pageSize;
    this.printingEditionsFilterModel.pageCount = this.pageIndex;

    this.GetPrintingEditions();
  }

  sortData(event: MatSort) {
    if (event.active === 'id') {
      this.printingEditionsFilterModel.SortType = PrintingEditionSortType.id;
    }

    if (event.active === 'name') { //todo use enums
      this.printingEditionsFilterModel.SortType = PrintingEditionSortType.name;
    }

    if (event.active === 'price') {
      this.printingEditionsFilterModel.SortType = PrintingEditionSortType.price;
    }

    if (event.direction === 'asc') {
      this.printingEditionsFilterModel.sortingDirection = SortingDirection.lowToHigh;
    }

    if (event.direction === 'desc') {
      this.printingEditionsFilterModel.sortingDirection = SortingDirection.highToLow;
    }

    this.GetPrintingEditions();
  }

  FilterPrintingEditions() {

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
}
