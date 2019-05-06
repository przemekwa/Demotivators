import { ModalService } from './modal.service';
import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { faUser, faRandom, faPaperPlane } from '@fortawesome/free-solid-svg-icons';
import { UserService } from './user.service';

interface AppFormValue {
  pageNumber: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit {

  faUser = faUser;
  faRandom = faRandom;
  faPaperPlane = faPaperPlane;
  public userName: string;

  constructor(private router: Router, private modalService: ModalService, private userService: UserService) {
  }

  title = 'DemotivatorsWeb';

  ngAfterViewInit(): void {
    if(this.userService.IsLogged) {
      this.userName = this.userService.UserName;
    } else  {
      this.modalService.open('custom-modal-1');
    }
  }

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
    this.modalService.open(id);
  }

  closeModal(id: string) {
    this.modalService.close(id);
    this.userService.UserName = this.userName;
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
