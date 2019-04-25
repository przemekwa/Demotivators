import { Component } from '@angular/core';

interface AppFormValue {
  pageNumber: number;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DemotivatorsWeb';

  onSubmit(formValue: AppFormValue) {
  console.log(formValue.pageNumber)
}

}




