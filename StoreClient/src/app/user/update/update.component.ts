import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { UserService } from 'src/app/shared/services/user-service';
import { FormBuilder } from '@angular/forms';
import { BaseConstants } from 'src/app/shared/constans/base-constants';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css'],
  providers: [UserService]
})
export class UpdateComponent {

  updateForm;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private userService: UserService, private formBuilder: FormBuilder) {


    this.updateForm = this.formBuilder.group({
      firstName: BaseConstants.stringEmpty,
      lastName: BaseConstants.stringEmpty
    });

  }

  save() {
    this.data.firstName = this.updateForm.value.firstName;
    this.data.lastName = this.updateForm.value.lastName;
    this.userService.update(this.data).subscribe();
  }
}
