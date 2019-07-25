import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from './Models/course.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  items: Array<Course>;
  show: boolean = false;

  constructor(private http:HttpClient){
    
  }

  ngOnInit(): void {
    this.http.get<Array<Course>>('https://localhost:5001/Home/CoursesAngular?module=RII').subscribe(
      response => {
        this.items = response as Array<Course>;
      }
    )
  }
}
