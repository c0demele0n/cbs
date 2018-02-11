import { Component, OnInit } from '@angular/core';
import { DataOwner } from '../../domain/data-owner';
import { StaffUserService } from '../../services/staff-user.service';
import { Router } from '@angular/router';

export const DATA_OWNER_PATH = 'data-owner';

@Component({
  selector: 'cbs-user-form-data-owner',
  templateUrl: './user-form-data-owner.component.html',
  styleUrls: ['./user-form-data-owner.component.scss']
})
export class UserFormDataOwnerComponent implements OnInit {

  user = new DataOwner({});
  public errorMsg = 'Something went wrong, try again later';
  public successMsg = 'User added';
  public success = false;
  public error = false;

  languageOptions = ['English', 'French'];

  constructor(private staffUserService: StaffUserService, private router: Router) {
  }

  ngOnInit() {
  }

  submit() {
    this.staffUserService.saveUser(this.user).subscribe(
      data => {
        this.success = true;
        console.log(data);
        setTimeout(() => this.router.navigateByUrl(''), 3000)
      },
      error => {
        this.error = true;
        console.error(error)
      })
  }
}
