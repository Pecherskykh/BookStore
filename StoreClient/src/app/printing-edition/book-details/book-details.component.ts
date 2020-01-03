import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { Subscription } from 'rxjs';
import { PrintingEditionService } from 'src/app/shared/services/printing-edition-service';
import { PrintingEditionModelItem } from 'src/app/shared/models/PeintingEditions/printing-edition-model-item';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css'],
  providers: [PrintingEditionService]
})
export class BookDetailsComponent implements OnInit {

  id: number;
  quantity: FormControl;
  printingEdition: PrintingEditionModelItem;
  subscription: Subscription;

  constructor(private activateRoute: ActivatedRoute, private printingEditionService: PrintingEditionService ) {
    this.quantity = new FormControl(1);
    this.subscription = activateRoute.params.subscribe(params => this.id = params['id']);
  }

  findById() {
    this.printingEditionService.findById(this.id).subscribe((data: PrintingEditionModelItem) => {
      this.printingEdition = data;
    });
  }

  ngOnInit() {
    this.findById();
  }

}
