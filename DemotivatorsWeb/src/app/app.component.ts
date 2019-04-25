import { Component } from '@angular/core';
import { Router } from '@angular/router';

interface AppFormValue {
  pageNumber: number;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private router: Router)
  {

  }

  title = 'DemotivatorsWeb';

  onSubmit(formValue: AppFormValue) {
  this.router.navigate(['/demotivators/' + formValue.pageNumber]);
}
}




