import { Component, OnInit } from '@angular/core';
import {AuthorService} from 'src/app/shared/services/author-service';
import {AuthorModelItem} from 'src/app/shared/models/Authors/author-model-item';
import {BaseFilterModel} from 'src/app/shared/models/Base/base-filter-model';
import { FormControl } from '@angular/forms';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';
import {PageEvent, MatDialog, MatSort} from '@angular/material';
import { CreateComponent } from '../create/create.component';
import { UpdateComponent } from '../update/update.component';
import { RemoveComponent } from '../remove/remove.component';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css'],
  providers: [AuthorService]
})

export class AuthorsComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'product', 'editAndRemove'];
  searchByName = new FormControl('');
  items: Array<AuthorModelItem>;
  amountPages: number;
  pageIndex: number;
  baseFilterModel = new BaseFilterModel();

  constructor(private authorService: AuthorService, public dialog: MatDialog) { }

  ngOnInit() {
    this.pageIndex = 0;
    this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.baseFilterModel.pageSize = 10;
    this.baseFilterModel.pageCount = 0;
    this.getAuthors();
  }

  getAuthors() {
    this.authorService.getData(this.baseFilterModel).subscribe(data => {
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
    const dialogRef = this.dialog.open(RemoveComponent, {data: authorModelItem}).
    afterClosed().subscribe(() => this.getAuthors());
  }

  create() {
    const dialogRef = this.dialog.open(CreateComponent).afterClosed().subscribe(() => this.getAuthors());
  }

  edit(authorModelItem: AuthorModelItem) {
    const dialogRef = this.dialog.open(UpdateComponent, {data: authorModelItem});
  }

  getServerData(event: PageEvent) {
    this.pageIndex = event.pageIndex;
    this.baseFilterModel.pageSize = event.pageSize;
    this.baseFilterModel.pageCount = this.pageIndex;
    this.getAuthors();
  }

  sortData(event: MatSort) {
    if (event.direction === 'asc') {
      this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    }
    if (event.direction === 'desc') {
      this.baseFilterModel.sortingDirection = SortingDirection.highToLow;
    }
    this.getAuthors();
  }
}
