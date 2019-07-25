import { Component, OnInit } from '@angular/core';
import { CoursesService } from 'src/app/Services/courses.service';
import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/Models/course.model';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

  course: Course;

  constructor(private coursesService: CoursesService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.coursesService.getCourse(this.route.snapshot.params['id']).subscribe(
      response => {
        this.course = response as Course
      }
    );
  }

}
