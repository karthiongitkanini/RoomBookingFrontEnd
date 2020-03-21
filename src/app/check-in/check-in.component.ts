import { Component, OnInit } from '@angular/core';
import { BookModel } from '../Models/book-model';
import{Router} from '@angular/router';

@Component({
  selector: 'app-check-in',
  templateUrl: './check-in.component.html',
  styleUrls: ['./check-in.component.scss']
})
export class CheckInComponent implements OnInit {

  constructor(private router:Router) {
  }
  goToHome() {
    this.router.navigate(["home"]);
  }
  ngOnInit(): void {
  }

}
