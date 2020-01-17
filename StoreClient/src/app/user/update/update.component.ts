import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { UserService } from 'src/app/shared/services/user-service';
import { FormBuilder, FormControl, Validators, FormGroup } from '@angular/forms';
import { BaseModel } from 'src/app/shared/models/Base/base-model';
import { ErrorListComponent } from 'src/app/shared/components/error-list/error-list.component';
import { UserModelItem } from 'src/app/shared/models/Users/user-model-item';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css'],
  providers: [UserService]
})
export class UpdateComponent {

  updateForm: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: UserModelItem,
    private userService: UserService,
    private formBuilder: FormBuilder,
    private dialog: MatDialog
    ) {

    this.updateForm = this.formBuilder.group({
      firstName: new FormControl(this.data.firstName, [Validators.required]),
      lastName: new FormControl(this.data.lastName, [Validators.required])
    });
  }

  save() {
    this.data.firstName = this.updateForm.value.firstName;
    this.data.lastName = this.updateForm.value.lastName;
    this.userService.update(this.data).subscribe((data: BaseModel) => {
      if (data.errors.length > 0) {
        let dialogRef = this.dialog.open(ErrorListComponent, {data: data.errors});
      }
    });
  }
}
