import { Component } from '@angular/core';
import { Console } from 'console';
import { ServerStreamFileResponseOptions } from 'http2';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'first_App';

  // Property Binding
  buttonDisabled = true;

  // Event Binding
  value:string="";

  constructor() {


  }

  // Event Binding
  ButtonDisabledChange(){
    this.buttonDisabled=false;
  }

  getEvent(event:any){
    console.log(event);
  }

  getValue(){
      this.value ="Hello";
  }



}
