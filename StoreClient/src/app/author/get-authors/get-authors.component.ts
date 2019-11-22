import { Component, OnInit } from '@angular/core';
import {AuthorService} from 'src/app/shared/services/author-service';
import {AuthorModelItem} from 'src/app/shared/models/Authors/author-model-item';
import {BaseFilterModel} from 'src/app/shared/models/Base/base-filter-model';
import { FormControl } from '@angular/forms';
import {SortingDirection} from 'src/app/shared/enums/sorting-direction';

@Component({
  selector: 'app-get-authors',
  templateUrl: './get-authors.component.html',
  styleUrls: ['./get-authors.component.css'],
  providers: [AuthorService]
})
export class GetAuthorsComponent implements OnInit {

  constructor(private authorService: AuthorService) { }

  searchByName = new FormControl('');
  sortingDirection = new FormControl('');
  nameAuthor = new FormControl('');

  items: Array<AuthorModelItem>;

  amountPages: number;
  countPage = 1;

  baseFilterModel = new BaseFilterModel();

  GetAuthors() {
    this.countPage = 1;
    this.baseFilterModel.PageCount = this.countPage;
    this.baseFilterModel.searchString = this.searchByName.value;
    if (this.sortingDirection.value === 'Low To High') {
      this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    }
    if (this.sortingDirection.value === 'High To Low') {
      this.baseFilterModel.sortingDirection = SortingDirection.highToLow;
    }
    this.authorService.getData(this.baseFilterModel).subscribe(data => {
      this.items = data.items;
      this.amountPages = data.pageAmount;
  });
}

  Create() {
    const authorModelItem = new AuthorModelItem();
    authorModelItem.name = this.nameAuthor.value;
    this.authorService.create(authorModelItem).subscribe();
    this.authorService.getData(this.baseFilterModel).subscribe(data => {
      this.items = data.items;
      this.amountPages = data.pageAmount;
  });
}

  Previous() {
    if (this.countPage > 1) {
      --this.countPage;
    }
    this.baseFilterModel.PageCount = this.countPage;
    this.authorService.getData(this.baseFilterModel).subscribe(data => {
      this.items = data.items;
  });
  }

  Next() {
    if (this.countPage < this.amountPages) {
      ++this.countPage;
    }
    this.baseFilterModel.PageCount = this.countPage;
    this.authorService.getData(this.baseFilterModel).subscribe(data => {
      this.items = data.items;
  });
  }

  ngOnInit() {
    this.baseFilterModel.sortingDirection = SortingDirection.lowToHigh;
    this.baseFilterModel.PageSize = 10;
    this.baseFilterModel.PageCount = this.countPage;
    this.authorService.getData(this.baseFilterModel).subscribe(data => {
      this.items = data.items;
      this.amountPages = data.pageAmount;
  });
  }
}
