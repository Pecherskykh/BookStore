import { Component, OnInit } from '@angular/core';
import {PrintingEditionService} from 'src/app/shared/services/printing-edition-service';
import {PrintingEditionModelItem} from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import {PrintingEditionsFilterModel} from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { FormControl } from '@angular/forms';
import {PrintingEditionSortType} from 'src/app/shared/enums/printing-edition-sort-type';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';
import {TypePrintingEdition} from 'src/app/shared/enums/type-printing-edition';
import { MatDialog, PageEvent, MatSort } from '@angular/material';
import { CreateComponent } from '../create/create.component';
import { RemoveComponent } from '../remove/remove.component';
import { UpdateComponent } from 'src/app/printing-edition/update/update.component';

@Component({
  selector: 'app-printing-edition-management',
  templateUrl: './printing-edition-management.component.html',
  styleUrls: ['./printing-edition-management.component.css'],
  providers: [PrintingEditionService]
})

export class PrintingEditionManagementComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'description', 'category', 'author', 'price', 'editAndRemove']; //todo use const, init on constr
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
    this.printingEditionsFilterModel.Categories =
    [
      TypePrintingEdition.book,
      TypePrintingEdition.magazine,
      TypePrintingEdition.newspaper
    ];

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
    let dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe(() => this.GetPrintingEditions());
  }

  remove(element: PrintingEditionModelItem) {
    let dialogRef = this.dialog.open(RemoveComponent, {data: element}).afterClosed().subscribe(() => this.GetPrintingEditions());
  }

  edit(element: PrintingEditionModelItem) {
    let dialogRef = this.dialog.open(UpdateComponent, {data: element}).afterClosed().subscribe(() => this.GetPrintingEditions());
  }

  private GetPrintingEditions() { //todo return type
    this.printingEditionService.getData(this.printingEditionsFilterModel).subscribe(data => { //todo data -> add type, check errors (use Base functions)
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

    this.typePrintingEdition.value.forEach(element => {
      this.printingEditionsFilterModel.Categories.push(TypePrintingEdition[element]);
    });

    this.GetPrintingEditions();
  }
}
