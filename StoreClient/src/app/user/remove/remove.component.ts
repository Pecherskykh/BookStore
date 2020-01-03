import { Component, Inject } from '@angular/core';
import { UserService } from 'src/app/shared/services/user-service';
import { MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css'],
  providers: [UserService]
})
export class RemoveComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private userService: UserService) { }

  remove() {
    this.userService.remove(this.data).subscribe();
  }
}
