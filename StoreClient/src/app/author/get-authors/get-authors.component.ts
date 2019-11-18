import { Component, OnInit } from '@angular/core';
import {AuthorService} from 'src/app/shared/services/author-service';
import {AuthorModelItem} from 'src/app/shared/models/Authors/author-model-item';

@Component({
  selector: 'app-get-authors',
  templateUrl: './get-authors.component.html',
  styleUrls: ['./get-authors.component.css'],
  providers: [AuthorService]
})
export class GetAuthorsComponent implements OnInit {

  constructor(private authorService: AuthorService) { }

  items: Array<AuthorModelItem>;

  GetAuthors() {
    this.authorService.getData().subscribe(data => {
      this.items = data.items;
  });
}
  ngOnInit() {
  }
}
