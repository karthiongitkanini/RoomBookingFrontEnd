import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BookingService } from 'src/Services/booking-service';
import { HttpClientModule } from '@angular/common/http';
import { CheckInComponent } from './check-in/check-in.component';
import{Route,RouterModule} from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';



const myRoutes:Route[]=[{path:'',redirectTo:'home',pathMatch:'full'},
                        {path:'home',component:HomepageComponent},
                        {path:'checkin',component:CheckInComponent}
                        ]
 
@NgModule({
  declarations: [
    AppComponent,
    CheckInComponent,
    HomepageComponent
  ],
  imports: [
     BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(myRoutes)
  ],
  providers: [BookingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
