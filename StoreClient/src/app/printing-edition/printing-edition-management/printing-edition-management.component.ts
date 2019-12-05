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

@Component({
  selector: 'app-printing-edition-management',
  templateUrl: './printing-edition-management.component.html',
  styleUrls: ['./printing-edition-management.component.css'],
  providers: [PrintingEditionService]
})

export class PrintingEditionManagementComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'description', 'category', 'author', 'price', 'editAndRemove'];
  items: Array<PrintingEditionModelItem>;
  searchByName = new FormControl('');
  sortType = new FormControl('');
  sortingDirection = new FormControl('');
  minPrice = new FormControl('');
  maxPrice = new FormControl('');
  books = new FormControl('');
  magazines = new FormControl('');
  newspapers = new FormControl('');
  printingEditionsFilterModel: PrintingEditionsFilterModel;

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
  }

  ngOnInit() {
    this.GetPrintingEditions();
  }

  create() {
    let dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe(() => this.GetPrintingEditions());
  }

  remove() {
    let dialogRef = this.dialog.open(RemoveComponent).afterClosed().subscribe(() => this.GetPrintingEditions());
  }

  GetPrintingEditions() {
    this.printingEditionService.getData(this.printingEditionsFilterModel).subscribe(data => {
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

    if (event.active === 'name') {
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

    if (this.books.value) {
      this.printingEditionsFilterModel.Categories[0] = TypePrintingEdition.book;
    }
    if (this.magazines.value) {
      this.printingEditionsFilterModel.Categories[this.printingEditionsFilterModel.Categories.length] = TypePrintingEdition.magazine;
    }
    if (this.newspapers.value) {
      this.printingEditionsFilterModel.Categories[this.printingEditionsFilterModel.Categories.length] = TypePrintingEdition.newspaper;
    }
    this.GetPrintingEditions();
  }
}
