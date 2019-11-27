import { Component, OnInit } from '@angular/core';
import { AuthorModelItem } from 'src/app/shared/models/Authors/author-model-item';
import { FormControl } from '@angular/forms';
import { AuthorService } from 'src/app/shared/services/author-service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  providers: [AuthorService]
})
export class CreateComponent implements OnInit {

  nameAuthor = new FormControl('');

  constructor(private authorService: AuthorService) { }

  create() {
    const authorModelItem = new AuthorModelItem();
    authorModelItem.name = this.nameAuthor.value;
    this.authorService.create(authorModelItem).subscribe();
  }

  ngOnInit() {
  }

}
