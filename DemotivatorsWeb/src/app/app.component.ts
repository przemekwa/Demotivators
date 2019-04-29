import { ModalService } from './modal.service';
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
  private bodyText: string;

  constructor(private router: Router, private modalService: ModalService) {
    this.bodyText = 'Działa';
  }

  title = 'DemotivatorsWeb';

  getRandom() {
    const pageNumber = Math.floor(Math.random() * (3000 - 1 + 1)) + 1;
    const pageNumberjbzb = Math.floor(Math.random() * (200 - 1 + 1)) + 1;

    if (this.router.url.indexOf('jbzdy') > 0) {
      this.router.navigate(['/jbzdy/' + pageNumberjbzb]);
      return;
    }

    if (this.router.url.indexOf('demotivators') > 0) {
      this.router.navigate(['/demotivators/' + pageNumber]);
      return;
    }

    this.router.navigate(['/demotivators/' + pageNumber]);
  }

  openModal(id: string) {
    console.log('Działa');
    this.modalService.open(id);
  }

  closeModal(id: string) {
    this.modalService.close(id);
  }

  onSubmit(formValue: AppFormValue) {
    if (this.router.url.indexOf('jbzdy') > 0) {
      this.router.navigate(['/jbzdy/' + formValue.pageNumber]);
      return;
    }

    if (this.router.url.indexOf('demotivators') > 0) {
      this.router.navigate(['/demotivators/' + formValue.pageNumber]);
      return;
    }

    this.router.navigate(['/demotivators/' + formValue.pageNumber]);
  }
}
