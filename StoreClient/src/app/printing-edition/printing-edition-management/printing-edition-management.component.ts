import { Component, OnInit } from '@angular/core';
import {PrintingEditionService} from 'src/app/shared/services/printing-edition-service';
import {PrintingEditionModelItem} from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';

import {PrintingEditionsFilterModel} from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { FormControl } from '@angular/forms';
import {PrintingEditionSortType} from 'src/app/shared/enums/printing-edition-sort-type';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';
import {TypePrintingEdition} from 'src/app/shared/enums/type-printing-edition';

@Component({
  selector: 'app-printing-edition-management',
  templateUrl: './printing-edition-management.component.html',
  styleUrls: ['./printing-edition-management.component.css'],
  providers: [PrintingEditionService]
})

export class PrintingEditionManagementComponent implements OnInit {

  constructor(private printingEditionService: PrintingEditionService) { }

  items: Array<PrintingEditionModelItem>;

  searchByName = new FormControl('');
  sortType = new FormControl('');
  sortingDirection = new FormControl('');
  minPrice = new FormControl('');
  maxPrice = new FormControl('');
  books = new FormControl('');
  magazines = new FormControl('');
  newspapers = new FormControl('');

  GetPrintingEditions() {
    const printingEditionsFilterModel = new PrintingEditionsFilterModel();
    printingEditionsFilterModel.searchString = this.searchByName.value;

    printingEditionsFilterModel.MinPrice = Number.parseFloat(this.minPrice.value);
    printingEditionsFilterModel.MaxPrice = Number.parseFloat(this.maxPrice.value);

    printingEditionsFilterModel.Categories = new Array<TypePrintingEdition>();

    if (this.books.value) {
      printingEditionsFilterModel.Categories[0] = TypePrintingEdition.book;
    }
    if (this.magazines.value) {
      printingEditionsFilterModel.Categories[printingEditionsFilterModel.Categories.length] = TypePrintingEdition.magazine;
    }
    if (this.newspapers.value) {
      printingEditionsFilterModel.Categories[printingEditionsFilterModel.Categories.length] = TypePrintingEdition.newspaper;
    }

    if (this.sortType.value === 'Id') {
      printingEditionsFilterModel.SortType = PrintingEditionSortType.id;
    }
    if (this.sortType.value === 'Name') {
      printingEditionsFilterModel.SortType = PrintingEditionSortType.name;
    }
    if (this.sortType.value === 'Category') {
      printingEditionsFilterModel.SortType = PrintingEditionSortType.category;
    }
    if (this.sortType.value === 'Author') {
      printingEditionsFilterModel.SortType = PrintingEditionSortType.author;
    }
    if (this.sortType.value === 'Price') {
      printingEditionsFilterModel.SortType = PrintingEditionSortType.price;
    }

    if (this.sortingDirection.value === 'Low To High') {
      printingEditionsFilterModel.sortingDirection = SortingDirection.lowToHigh;
    }
    if (this.sortingDirection.value === 'High To Low') {
      printingEditionsFilterModel.sortingDirection = SortingDirection.highToLow;
    }

    printingEditionsFilterModel.PageSize = 10;
    printingEditionsFilterModel.PageCount = 1;

    this.printingEditionService.getData(printingEditionsFilterModel).subscribe(data => {
      this.items = data.items;
  });
}

  ngOnInit() {
  }

}
