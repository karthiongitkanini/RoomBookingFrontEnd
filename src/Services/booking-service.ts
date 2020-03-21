import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BookModel } from '../app/Models/book-model'
import { HttpHeaders } from "@angular/common/http";
@Injectable({
    providedIn: 'root'
})
export class BookingService {
    private readonly myroot = "https://localhost:44374/";
    roomsAvailabilityList:any=[];
    constructor(private myHttp: HttpClient) { }
    checkIn(values:BookModel) {
     this.myHttp.post(this.myroot + "api/Booking",values).subscribe(res=>{
         console.log(res);
     });        
    } 
    checkAvailability(timeSlot:string){
       return this.myHttp.get(this.myroot+"api/Booking?timeSlot="+timeSlot);
    }
}
