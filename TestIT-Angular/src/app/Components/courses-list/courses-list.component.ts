import { Component, OnInit } from '@angular/core';
import { Course } from '../../Models/course.model';
import { CoursesService } from '../../Services/courses.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})
export class CoursesListComponent implements OnInit {

  courses: Array<Course>;
  modules: Array<string>;

  constructor(private coursesService: CoursesService, private router: Router) {

  }

  ngOnInit() {
    this.coursesService.getModules().subscribe(
      response => {
        this.modules = response as Array<string>;
      });
  }

  onModuleChosen(module: string) {
    this.coursesService.getCourses(module).subscribe(
      response => {
        this.courses = response as Array<Course>;
      });
  }

  onCourseChosen(id: number) {
    this.router.navigate(['/courses', id]);
  }

}
