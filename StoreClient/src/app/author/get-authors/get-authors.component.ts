import { Component, OnInit, ViewChild } from '@angular/core';
import {AuthorService} from 'src/app/shared/services/author-service';
import {AuthorModelItem} from 'src/app/shared/models/Authors/author-model-item';
import {BaseFilterModel} from 'src/app/shared/models/Base/base-filter-model';
import { FormControl } from '@angular/forms';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';
import {MatPaginator, MatTableDataSource} from '@angular/material';

@Component({
  selector: 'app-get-authors',
  templateUrl: './get-authors.component.html',
  styleUrls: ['./get-authors.component.css'],
  providers: [AuthorService]
})

export class GetAuthorsComponent implements OnInit {

  displayedColumns: string[] = ['id', 'name', 'product', 'editAndRemove'];

  constructor(private authorService: AuthorService) { }

  searchByName = new FormControl('');
  sortingDirection = new FormControl('');
  nameAuthor = new FormControl('');

  items: Array<AuthorModelItem>;

  dataSource = new MatTableDataSource(this.items);

  amountPages: number;
  countPage = 1;

  baseFilterModel = new BaseFilterModel();

  getAuthors() {
    this.authorService.getData(this.baseFilterModel).subscribe(data => {
      this.items = data.items;
      this.amountPages = data.pageAmount;
  });
  }

  filterAuthors() {
    this.countPage = 1;
    this.baseFilterModel.pageCount = this.countPage;
    this.baseFilterModel.searchString = this.searchByName.value;
    if (this.sortingDirection.value === 'Low To High') {
      this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    }
    if (this.sortingDirection.value === 'High To Low') {
      this.baseFilterModel.sortingDirection = SortingDirection.highToLow;
    }
    this.getAuthors();
}

  Create() {
    const authorModelItem = new AuthorModelItem();
    authorModelItem.name = this.nameAuthor.value;
    this.baseFilterModel.pageCount = this.amountPages;
    this.authorService.create(authorModelItem).subscribe(() => {
      this.getAuthors();
    });
}

  Remove(authorModelItem: AuthorModelItem) {
    this.authorService.remove(authorModelItem).subscribe(() => {
      this.getAuthors();
      }
    );
  }

  OpenEditModal(authorModelItem: AuthorModelItem) {
    this.authorService.remove(authorModelItem).subscribe(() => {
      this.getAuthors();
      }
    );
  }

  Previous() {
    if (this.countPage > 1) {
      --this.countPage;
    }
    this.baseFilterModel.pageCount = this.countPage;
    this.getAuthors();
  }

  Next() {
    if (this.countPage < this.amountPages) {
      ++this.countPage;
    }
    this.baseFilterModel.pageCount = this.countPage;
    this.getAuthors();
  }

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.baseFilterModel.pageSize = 10;
    this.baseFilterModel.pageCount = this.countPage;
    this.getAuthors();
  }


}
