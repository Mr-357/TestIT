import { Component, OnInit } from '@angular/core';
import { Course } from '../Models/course.model';
import { CoursesService } from '../Services/courses.service';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})
export class CoursesListComponent implements OnInit {

  courses: Array<Course>;

  constructor(private coursesService: CoursesService) { }

  ngOnInit() {

  }

  onModuleChosen(module: string) {
    this.coursesService.getCourses(module).subscribe(
      response => {
        this.courses = response as Array<Course>;
        console.log(this.courses)
      });
  }

}
