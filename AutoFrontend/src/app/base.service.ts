import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  url="https://localhost:7231/api/Jarmu" //ezt a swaggeren felül a cím alatt látjuk
  private carsSub=new Subject()

  constructor(private http:HttpClient) { 
    this.loadCars();
  }

  loadCars() {
    this.http.get(this.url).subscribe(
      (res)=>this.carsSub.next(res)
    )
  }

  getCars(){  //az autókat kérjük le
    this.loadCars();
    return this.carsSub;
  }

  addCar(car: any) {  //hozzáadunk autót
    return this.http.post<any>(this.url, car);  //hozzáadunk autót, amit elküldünk a post metódussal
  }
}