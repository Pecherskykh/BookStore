import { Component, OnInit } from '@angular/core';
import {AuthorService} from 'src/app/shared/services/author-service';
import {AuthorModelItem} from 'src/app/shared/models/Authors/author-model-item';
import {BaseFilterModel} from 'src/app/shared/models/Base/base-filter-model';
import { FormControl } from '@angular/forms';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';
import {MatPaginator, MatTableDataSource, PageEvent, MatDialog} from '@angular/material';
import { CreateComponent } from '../create/create.component';
import { UpdateComponent } from '../update/update.component';

@Component({
  selector: 'app-get-authors',
  templateUrl: './get-authors.component.html',
  styleUrls: ['./get-authors.component.css'],
  providers: [AuthorService]
})

export class GetAuthorsComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'product', 'editAndRemove'];

  constructor(private authorService: AuthorService, public dialog: MatDialog) { }

  searchByName = new FormControl('');
  sortingDirection = new FormControl('');
  nameAuthor = new FormControl('');

  items: Array<AuthorModelItem>;

  dataSource = new MatTableDataSource(this.items);

  amountPages: number;
  pageIndex: number;

  baseFilterModel = new BaseFilterModel();

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
    if (this.sortingDirection.value === 'Low To High') {
      this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    }
    if (this.sortingDirection.value === 'High To Low') {
      this.baseFilterModel.sortingDirection = SortingDirection.highToLow;
    }
    this.getAuthors();
}

  Remove(authorModelItem: AuthorModelItem) {
    this.authorService.remove(authorModelItem).subscribe(() => {
      this.getAuthors();
      }
    );
  }

  create() {
    const dialogRef = this.dialog.open(CreateComponent);
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

  ngOnInit() {
    this.pageIndex = 0;
    this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.baseFilterModel.pageSize = 10;
    this.baseFilterModel.pageCount = 0;
    this.getAuthors();
  }
}
