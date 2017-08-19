import { Component, OnInit, Input, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-countdown',
  templateUrl: './countdown.component.html',
  styleUrls: ['./countdown.component.css']
})
export class CountdownComponent implements OnInit {
  @Input() finalDate: string;
    
  days = {value: 0, cols: 1, rows: 1, color: 'lightblue'}
  hours = {value: 0, cols: 1, rows: 1, color: 'lightgreen'}
  minutes = {value: 0, cols: 1, rows: 1, color: 'lightpink'}
  seconds = {value: 0, cols: 1, rows: 1, color: '#DDBDF1'}

  expired:boolean = false;

  constructor() { }

  ngOnInit() {
  }

  ngAfterViewInit(){
    this.countDown();
  }

  get columnCnt(){
    if (window.screen.width < 600)
      return 2;
    
    return 4;
  };
  
  countDown(){
    var countdownFunc = setInterval(() => {

      // Get todays date and time
      var now = new Date().getTime();

      // Find the distance between now an the count down date
      var distance = Date.parse(this.finalDate) - now;

      // Time calculations for days, hours, minutes and seconds
      this.days.value = Math.floor(distance / (1000 * 60 * 60 * 24));
      this.hours.value = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      this.minutes.value = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      this.seconds.value = Math.floor((distance % (1000 * 60)) / 1000);

      // Display the result in an element with id="demo"
      /*document.getElementById("demo").innerHTML = this.days + "d " + this.hours + "h "
      + this.minutes + "m " + this.seconds + "s ";*/

      // If the count down is finished, write some text 
      if (distance < 0) {
        clearInterval(countdownFunc);
        this.expired = true;
      }
    }, 1000);
  }

}
