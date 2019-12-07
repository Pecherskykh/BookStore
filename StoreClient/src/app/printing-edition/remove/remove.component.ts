import { Component, OnInit, Inject } from '@angular/core';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css'],
  providers: [PrintingEditionService]
})
export class RemoveComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private printingEditionService: PrintingEditionService) { }

  remove() {
    this.printingEditionService.remove(this.data).subscribe();
  }

  ngOnInit() {
  }

}
