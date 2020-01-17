import { Component, OnInit } from '@angular/core';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { PrintingEditionsFilterModel } from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { FormControl, FormBuilder } from '@angular/forms';
import { PrintingEditionSortType } from 'src/app/shared/enums/printing-edition-sort-type';
import { SortingDirection } from 'src/app/shared/enums/sorting-direction';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { MatDialog, PageEvent, MatSort } from '@angular/material';
import { RemoveComponent } from 'src/app/shared/components/remove/remove.component';
import { PrintingEditionDialogComponent } from '../printing-edition-dialog/printing-edition-dialog.component';
import { CreateUpdate } from 'src/app/shared/enums/create-update';
import { Currencys } from 'src/app/shared/enums/currencys';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';
import { PrintingEditionConstants } from 'src/app/shared/constans/printing-edition-constants';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { PaginationConstants } from 'src/app/shared/constans/pagination-constants';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';
import { PrintingEditionModel } from 'src/app/shared/models/PeintingEditions/printing-edition-model';
import { BaseModel } from 'src/app/shared/models/Base/base-model';

@Component({
  selector: 'app-printing-edition-management',
  templateUrl: './printing-edition-management.component.html',
  styleUrls: ['./printing-edition-management.component.css'],
  providers: [PrintingEditionService]
})

export class PrintingEditionManagementComponent implements OnInit {
  displayedColumns: string[]; //todo use const, init on constr
  typePrintingEditionItems: string[];
  items: Array<PrintingEditionModelItem>;
  printingEditionsFilterModel: PrintingEditionsFilterModel; //todo get default from const
  pageSizeOptions: number[];

  printingEditionManagementForm;

  countPrintingEditions: number;
  pageIndex: number;

  constructor(private printingEditionService: PrintingEditionService, public dialog: MatDialog, private formBuilder: FormBuilder) {

    this.pageSizeOptions = PaginationConstants.pageSizeOptions;

    this.printingEditionsFilterModel = new PrintingEditionsFilterModel();
    this.printingEditionsFilterModel.minPrice = BaseConstants.zero;
    this.printingEditionsFilterModel.maxPrice = PrintingEditionConstants.maxPrice;
    this.printingEditionsFilterModel.sortType = PrintingEditionSortType.id;
    this.printingEditionsFilterModel.pageCount = BaseConstants.zero;
    this.printingEditionsFilterModel.pageSize = this.pageSizeOptions[1];
    this.printingEditionsFilterModel.sortingDirection = SortingDirection.asc;
    this.printingEditionsFilterModel.currency = Currencys.USD;
    this.printingEditionsFilterModel.categories =
    [
      TypePrintingEdition.book,
      TypePrintingEdition.magazine,
      TypePrintingEdition.newspaper
    ];

    this.displayedColumns = DisplayedColumnsConstans.printingEditions;
    this.typePrintingEditionItems = PrintingEditionConstants.typePrintingEditionItems;

    this.printingEditionManagementForm = this.formBuilder.group({
      typePrintingEdition: new FormControl(this.typePrintingEditionItems),
      searchByName: BaseConstants.stringEmpty,
      minPrice: BaseConstants.zero,
      maxPrice: PrintingEditionConstants.maxPrice
    });
  }

  ngOnInit() {
    this.getPrintingEditions();
  }

  create(): void {
    let element = new PrintingEditionModelItem();
    let dialogRef = this.dialog.open(PrintingEditionDialogComponent, {data: {pageName: 'Add new Product', buttonName: 'Add',
    createUpdate: CreateUpdate.Create, printingEditionModelItem: element}}).
    afterClosed().subscribe(() => this.getPrintingEditions());
  }

  remove(element: PrintingEditionModelItem): void {
    let dialogRef = this.dialog.open(RemoveComponent, {data: {pageName: 'printing edition', name: element.title}})
    .afterClosed().subscribe(data => {
      if (data) {
      this.printingEditionService.remove(element).subscribe((baseDate: BaseModel) => {
        if (baseDate.errors.length > 0) {
            let dialogRef = this.dialog.open(ErrorListComponent, {data: baseDate.errors});
            return;
          }
        }
      );
      this.getPrintingEditions();
      }
    });
  }

  edit(element: PrintingEditionModelItem): void {
    let dialogRef = this.dialog.open(PrintingEditionDialogComponent, {data: {pageName:
      'Edit Product - ' + element.title, buttonName: 'Save',
    createUpdate: CreateUpdate.Update, printingEditionModelItem: element}}).
    afterClosed().subscribe(() => this.getPrintingEditions());
  }

  private getPrintingEditions(): void { //todo return type
    this.printingEditionService.getData(this.printingEditionsFilterModel).subscribe((data: PrintingEditionModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
        return;
      }
      this.countPrintingEditions = data.countPrintingEditions;
      this.items = data.items;
  });
}

  getServerData(event: PageEvent): void {
    this.pageIndex = event.pageIndex;

    this.printingEditionsFilterModel.pageSize = event.pageSize;
    this.printingEditionsFilterModel.pageCount = this.pageIndex;

    this.getPrintingEditions();
  }

  sortData(event: MatSort): void {
    if (event.active === PrintingEditionSortType[PrintingEditionSortType.id]) {
      this.printingEditionsFilterModel.sortType = PrintingEditionSortType.id;
    }

    if (event.active === PrintingEditionSortType[PrintingEditionSortType.name]) {
      this.printingEditionsFilterModel.sortType = PrintingEditionSortType.name;
    }

    if (event.active === PrintingEditionSortType[PrintingEditionSortType.price]) {
      this.printingEditionsFilterModel.sortType = PrintingEditionSortType.price;
    }

    if (event.direction === SortingDirection[SortingDirection.asc]) {
      this.printingEditionsFilterModel.sortingDirection = SortingDirection.asc;
    }

    if (event.direction === SortingDirection[SortingDirection.desc]) {
      this.printingEditionsFilterModel.sortingDirection = SortingDirection.desc;
    }

    this.getPrintingEditions();
  }

  filterPrintingEditions(): void {

    this.pageIndex = 0;

    this.printingEditionsFilterModel.pageCount = 0;

    this.printingEditionsFilterModel.searchString = this.printingEditionManagementForm.value.searchByName;
    this.printingEditionsFilterModel.minPrice = Number.parseFloat(this.printingEditionManagementForm.value.minPrice);
    this.printingEditionsFilterModel.maxPrice = Number.parseFloat(this.printingEditionManagementForm.value.maxPrice);
    this.printingEditionsFilterModel.categories = new Array<TypePrintingEdition>();

    this.printingEditionManagementForm.value.typePrintingEdition.forEach((element: string) => {
      this.printingEditionsFilterModel.categories.push(TypePrintingEdition[element]);
    });

    this.getPrintingEditions();
  }
}
