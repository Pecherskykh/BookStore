import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { AuthorService } from 'src/app/shared/services/author-service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css'],
  providers: [AuthorService]
})
export class UpdateComponent implements OnInit {

  nameAuthor = new FormControl('');

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private authorService: AuthorService) { }

  save() {
    this.data.name = this.nameAuthor.value;
    this.authorService.update(this.data).subscribe();
  }

  ngOnInit() {
  }
}
