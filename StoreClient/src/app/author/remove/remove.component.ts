import { Component, OnInit, Inject } from '@angular/core';
import { AuthorService } from 'src/app/shared/services/author-service';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css'],
  providers: [AuthorService]
})
export class RemoveComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private authorService: AuthorService) { }

  remove() {
    this.authorService.remove(this.data).subscribe();
  }

  ngOnInit() {
  }
}
