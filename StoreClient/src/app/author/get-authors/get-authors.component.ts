import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-get-authors',
  templateUrl: './get-authors.component.html',
  styleUrls: ['./get-authors.component.css']
})
export class GetAuthorsComponent implements OnInit {

  constructor() { }

  Get() {
    for (let i = 0; i < 3; i++) {
      document.getElementById('t').innerHTML += '<tr><td></td><td></td><td></td></tr>';
    }
  }
  ngOnInit() {
  }
}
