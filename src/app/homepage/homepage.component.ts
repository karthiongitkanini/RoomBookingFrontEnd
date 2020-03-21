import { Component, OnInit } from '@angular/core';
import { BookModel } from '../Models/book-model';
import { BookingService } from 'src/Services/booking-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {

  bookModel = new BookModel();
  tempTimeSlot: string;
  tempUserId: string;
  pondyStatus;
  marinaStatus;
  bigbossStatus;
  covelongStatus;
  hibernateStatus;
  mahabsStatus;
  temptitle = 'RoomBooking';
  show: boolean = false;
  show1: string = "true";
  show2: string = "true";
  roomsAvailabilityList: any = [];
  now: number = Date.now();
  //value = '';
  constructor(private bookingService: BookingService, private router: Router) {

  }
  onEnter(event: any) {
    this.bookModel.UserId = event.target.value;
    this.show1 = "false";
  }
  getTimeSlot(event: any) {
    this.show2 = "false";
    this.bookModel.TimeSlot = event.target.value;
    this.tempTimeSlot = event.target.value;
    this.bookingService.checkAvailability(this.tempTimeSlot).subscribe(res => {
      this.roomsAvailabilityList = res;
      console.log(this.roomsAvailabilityList);
      if (this.roomsAvailabilityList[0].RoomName == "Pondy") {
        this.pondyStatus = this.roomsAvailabilityList[0].StatusOfRoom;
      }
      if (this.roomsAvailabilityList[1].RoomName == "Mahabs") {
        this.mahabsStatus = this.roomsAvailabilityList[1].StatusOfRoom;
      }
      if (this.roomsAvailabilityList[2].RoomName == "Bigboss") {
        this.bigbossStatus = this.roomsAvailabilityList[2].StatusOfRoom;
      }
      if (this.roomsAvailabilityList[3].RoomName == "Covelong") {
        this.covelongStatus = this.roomsAvailabilityList[3].StatusOfRoom;
      }
      if (this.roomsAvailabilityList[4].RoomName == "Hibernate") {
        this.hibernateStatus = this.roomsAvailabilityList[4].StatusOfRoom;
      }
      if (this.roomsAvailabilityList[5].RoomName == "Marina") {
        this.marinaStatus = this.roomsAvailabilityList[5].StatusOfRoom;
      }
      console.log(this.pondyStatus);
    });
  }
  getRoomName(name: string) {
    this.bookModel.RoomName = name;

    // this.bookingService.checkIn(this.bookModel);
    this.router.navigate(["checkin"]);
  }
  getAvailability() {
    this.show = true;
  }
  goToHome() {
    this.router.navigate(["home"]);
  }
  ngOnInit(): void {
  }
}
