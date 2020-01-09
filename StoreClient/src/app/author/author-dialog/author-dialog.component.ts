import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { AuthorService } from 'src/app/shared/services/author-service';
import { CreateUpdate } from 'src/app/shared/enums/create-update';
import { FormControl } from '@angular/forms';
import { AuthorModelItem } from 'src/app/shared/models/Authors/author-model-item';
import { BaseModel } from 'src/app/shared/models/Base/base-model';

@Component({
  selector: 'app-author-dialog',
  templateUrl: './author-dialog.component.html',
  styleUrls: ['./author-dialog.component.css'],
  providers: [AuthorService]
})
export class AuthorDialogComponent {

  nameAuthor: FormControl;
  errors: Array<string>;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private authorService: AuthorService) {
    this.nameAuthor = new FormControl(this.data.authorModelItem.name);
  }

  event(): void {
    if (this.data.createUpdate === CreateUpdate.Create) {
      this.create();
    }

    if (this.data.createUpdate === CreateUpdate.Update) {
      this.update();
    }
  }

  create(): void {
    let authorModelItem = new AuthorModelItem();
    authorModelItem.name = this.nameAuthor.value;
    this.authorService.create(authorModelItem).
    subscribe((data: BaseModel) => {
      this.errors = data.errors;
    });
  }

  update(): void {
    this.data.authorModelItem.name = this.nameAuthor.value;
    this.authorService.update(this.data.authorModelItem).
    subscribe((data: BaseModel) => {
      this.errors = data.errors;
    });
  }
}
