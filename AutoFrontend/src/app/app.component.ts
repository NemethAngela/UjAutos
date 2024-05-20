import { Component } from '@angular/core';
import { BaseService } from './base.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'AutoFrontend';
  cars:any;

  rendszam: any;
  marka: any;
  urtartalom: any;
  ar: any;

  constructor(private base:BaseService) {
    this.getCars();
  }

  getCars() {
    this.base.getCars().subscribe(
      (res)=>this.cars=res
    )
  }
  
  addCar(){
    //console.log("Működik", this.rendszam, this.marka, this.ar);
    let car = {
      azonosito: 0,
      rendszam: this.rendszam, 
      marka: this.marka,
      urtartalom: this.urtartalom,
      ar: this.ar,
    }

    console.log(car);

    this.base.addCar(car).subscribe({
      next: data => {
        console.log(data)
        this.getCars();
      }
    })
  }
}
