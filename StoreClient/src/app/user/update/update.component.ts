import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { UserService } from 'src/app/shared/services/user-service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css'],
  providers: [UserService]
})
export class UpdateComponent {

  firstName: FormControl;
  lastName: FormControl;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private userService: UserService) {
    this.firstName = new FormControl('');
    this.lastName = new FormControl('');
  }

  save() {
    this.data.firstName = this.firstName.value;
    this.data.lastName = this.lastName.value;
    this.userService.update(this.data).subscribe();
  }
}
