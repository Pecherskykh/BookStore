import { Component, OnInit } from '@angular/core';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { FormControl } from '@angular/forms';
import { PrintingEditionsFilterModel } from 'src/app/shared/models/PeintingEditions/printing-editions-filter-model';
import { SortingDirection } from 'src/app/shared/enums/sorting-direction';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { PrintingEditionSortType } from 'src/app/shared/enums/printing-edition-sort-type';
import { PageEvent } from '@angular/material';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
  providers: [PrintingEditionService]
})
export class HomePageComponent implements OnInit {


  currencies = ['USD', 'EUR', 'UAH'];

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
    this.printingEditionsFilterModel.MinPrice = 0;
    this.printingEditionsFilterModel.MaxPrice = 1000;
    this.printingEditionsFilterModel.SortType = PrintingEditionSortType.id;
    this.printingEditionsFilterModel.pageCount = 0;
    this.printingEditionsFilterModel.pageSize = 6;
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

    //this.printingEditionsFilterModel.searchString = this.searchByName.value;
    this.printingEditionsFilterModel.MinPrice = Number.parseFloat(this.minPrice.value);
    this.printingEditionsFilterModel.MaxPrice = Number.parseFloat(this.maxPrice.value);
    this.printingEditionsFilterModel.Categories = new Array<TypePrintingEdition>();

    this.typePrintingEdition.value.forEach((element: string) => {
      this.printingEditionsFilterModel.Categories.push(TypePrintingEdition[element]);
    });

    this.GetPrintingEditions();
  }

  getServerData(event: PageEvent) {
    this.pageIndex = event.pageIndex;

    this.printingEditionsFilterModel.pageSize = event.pageSize;
    this.printingEditionsFilterModel.pageCount = this.pageIndex;

    this.GetPrintingEditions();
  }

  ngOnInit() {
    this.GetPrintingEditions();
  }

}
