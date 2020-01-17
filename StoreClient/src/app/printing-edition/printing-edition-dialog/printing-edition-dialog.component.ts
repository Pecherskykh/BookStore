import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { CreateUpdate } from 'src/app/shared/enums/create-update';
import { AuthorModelItem } from 'src/app/shared/models/Authors/author-model-item';
import { FormControl, FormBuilder } from '@angular/forms';
import { Currencys } from 'src/app/shared/enums/currencys';
import { AuthorModel } from 'src/app/shared/models/Authors/author-model';
import { TypePrintingEdition } from 'src/app/shared/enums/type-printing-edition';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { AuthorService } from 'src/app/shared/services/author-service';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { PrintingEditionConstants } from 'src/app/shared/constans/printing-edition-constants';
import { BaseConstants } from 'src/app/shared/constans/base-constants';
import { BaseModel } from 'src/app/shared/models/Base/base-model';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';

@Component({
  selector: 'app-printing-edition-dialog',
  templateUrl: './printing-edition-dialog.component.html',
  styleUrls: ['./printing-edition-dialog.component.css'],
  providers: [AuthorService, PrintingEditionService]
})
export class PrintingEditionDialogComponent implements OnInit {

  items: Array<AuthorModelItem>;
  currencys: Array<string>;
  authors: FormControl;
  printingEditionDialogForm;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private authorService: AuthorService,
    private printingEditionService: PrintingEditionService,
    private formBuilder: FormBuilder,
    private dialog: MatDialog
    ) {
      this.printingEditionDialogForm = this.formBuilder.group({
        title: this.data.printingEditionModelItem.title,
        description: this.data.printingEditionModelItem.description,
        productType: TypePrintingEdition[this.data.printingEditionModelItem.productType],
        authors: new FormControl(),
        price: this.data.printingEditionModelItem.price,
        currency: BaseConstants.stringEmpty
      });
      this.authors = new FormControl();
      this.currencys = PrintingEditionConstants.currencys;
  }

  ngOnInit() {
    this.authorService.getAll().subscribe((data: AuthorModel) => {
      this.items = data.items;
      if (this.data.createUpdate === CreateUpdate.Update) {
        this.authors = new FormControl(this.selectedAuthors());
      }
  });
  }
  event() {
    if (this.data.createUpdate === CreateUpdate.Create) {
      this.create();
    }

    if (this.data.createUpdate === CreateUpdate.Update) {
      this.update();
    }
  }

  create() {
    let printingEditionModelItem = new PrintingEditionModelItem();

    let authorModel = new AuthorModel();
    authorModel.items = this.printingEditionDialogForm.value.authors;
    printingEditionModelItem.authors = authorModel;
    printingEditionModelItem.title = this.printingEditionDialogForm.value.title;
    printingEditionModelItem.description = this.printingEditionDialogForm.value.description;
    printingEditionModelItem.price = parseFloat(this.printingEditionDialogForm.value.price);

    //todo replace to private method
    if (this.printingEditionDialogForm.value.productType === TypePrintingEdition[TypePrintingEdition.book]) {
      printingEditionModelItem.productType = TypePrintingEdition.book;
    }
    if (this.printingEditionDialogForm.value.productType === TypePrintingEdition[TypePrintingEdition.magazine]) {
      printingEditionModelItem.productType = TypePrintingEdition.magazine;
    }
    if (this.printingEditionDialogForm.value.productType === TypePrintingEdition[TypePrintingEdition.newspaper]) {
      printingEditionModelItem.productType = TypePrintingEdition.newspaper;
    }

    printingEditionModelItem.currencys = Currencys[this.printingEditionDialogForm.value.currency as string];

    this.printingEditionService.create(printingEditionModelItem).subscribe((data: BaseModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
      }
    });
  }

  selectedAuthors() {
    let selected = new Array<AuthorModelItem>();
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.data.printingEditionModelItem.authors.items.length; i++) {
      // tslint:disable-next-line: prefer-for-of
      for (let j = 0; j < this.items.length; j++) {
        if (this.data.printingEditionModelItem.authors.items[i].id === this.items[j].id) {
          selected.push(this.items[j]);
        }
      }
    }
    return selected;
  }

  update() {
    this.data.printingEditionModelItem.title = this.printingEditionDialogForm.value.title;
    this.data.printingEditionModelItem.description = this.printingEditionDialogForm.value.description;
    this.data.printingEditionModelItem.productType = TypePrintingEdition[this.printingEditionDialogForm.value.productType];
    this.data.printingEditionModelItem.price = parseFloat(this.printingEditionDialogForm.value.price);
    this.data.printingEditionModelItem.currencys = Currencys[this.printingEditionDialogForm.value.currency];
    this.data.printingEditionModelItem.authors.items = this.authors.value;
    this.printingEditionService.update(this.data.printingEditionModelItem).subscribe((data: BaseModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
      }
    });
  }
}
