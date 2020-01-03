import { Component, OnInit } from '@angular/core';
import {AuthorService} from 'src/app/shared/services/author-service';
import {AuthorModelItem} from 'src/app/shared/models/Authors/author-model-item';
import {BaseFilterModel} from 'src/app/shared/models/Base/base-filter-model';
import { FormControl } from '@angular/forms';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';
import {PageEvent, MatDialog, MatSort} from '@angular/material';
import { AuthorModel } from 'src/app/shared/models/Authors/author-model';
import { RemoveComponent } from 'src/app/shared/components/remove/remove.component';
import { AuthorDialogComponent } from '../author-dialog/author-dialog.component';
import { CreateUpdate } from 'src/app/shared/enums/create-update';
import { DisplayedColumnsConstans } from 'src/app/shared/constans/displayed-columns-constans';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css'],
  providers: [AuthorService]
})

export class AuthorsComponent implements OnInit {

  displayedColumns: string[];
  searchByName: FormControl;
  items: Array<AuthorModelItem>;
  amountPages: number;
  pageIndex: number;
  baseFilterModel: BaseFilterModel;

  constructor(private authorService: AuthorService, public dialog: MatDialog) {
    this.displayedColumns = DisplayedColumnsConstans.authors;
    this.searchByName = new FormControl('');
    this.baseFilterModel = new BaseFilterModel();
  }

  ngOnInit() {
    this.pageIndex = 0;
    this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.baseFilterModel.pageSize = 10;
    this.baseFilterModel.pageCount = 0;

    this.getAuthors();
  }

  getAuthors() {
    this.authorService.getData(this.baseFilterModel).subscribe((data: AuthorModel) => {
      this.items = data.items;
      this.amountPages = data.pageAmount;
  });
  }

  filterAuthors() {
    this.pageIndex = 0;
    this.baseFilterModel.pageCount = 0;
    this.baseFilterModel.searchString = this.searchByName.value;
    this.getAuthors();
}

  remove(authorModelItem: AuthorModelItem) {
    let dialogRef = this.dialog.open(RemoveComponent, {data: {pageName: 'author', name: authorModelItem.name}})
    .afterClosed().subscribe(data => {
      if (data) {
      this.authorService.remove(authorModelItem).subscribe(() => this.getAuthors());
      }
    });
  }

  create() {
    let element = new AuthorModelItem();
    let dialogRef = this.dialog.open(AuthorDialogComponent, {data: {pageName: 'Add new Author', buttonName: 'Add',
    createUpdate: CreateUpdate.Create, authorModelItem: element}}).
    afterClosed().subscribe(() => this.getAuthors());
  }

  edit(element: AuthorModelItem) {
    let dialogRef = this.dialog.open(AuthorDialogComponent, {data: {pageName: 'Edit Author', buttonName: 'Save',
    createUpdate: CreateUpdate.Update, authorModelItem: element}}).
    afterClosed().subscribe(() => this.getAuthors());
  }

  getServerData(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.baseFilterModel.pageSize = event.pageSize;
    this.baseFilterModel.pageCount = this.pageIndex;
    this.getAuthors();
  }

  sortData(event: MatSort) {
    if (event.direction === SortingDirection[SortingDirection.asc]) {
      this.baseFilterModel.sortingDirection = SortingDirection.asc;
    }
    if (event.direction === SortingDirection[SortingDirection.desc]) {
      this.baseFilterModel.sortingDirection = SortingDirection.desc;
    }
    this.getAuthors();
  }
}
