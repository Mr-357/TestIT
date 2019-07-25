import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../Models/course.model';

@Injectable()
export class CoursesService{
    constructor(private http: HttpClient) {

    }

    getCourses(module:string) {
        return this.http.get<Array<Course>>('https://localhost:5001/Home/CoursesAngular?module=' + module);
    }

    getCourse(id:string){
        console.log(id)
        return this.http.get<Course>('https://localhost:5001/Home/CourseAngular/' + id);
    }
}