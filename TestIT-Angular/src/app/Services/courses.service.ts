import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../Models/course.model';

@Injectable()
export class CoursesService{

    constructor(private http: HttpClient) {

    }

    getModules(){
        return this.http.get<Array<string>>('https://localhost:5001/Home/GetModules');
    }

    getCourses(module:string) {
        return this.http.get<Array<Course>>('https://localhost:5001/Home/Courses?module=' + module);
    }

    getCourse(id:string){
        return this.http.get<Course>('https://localhost:5001/Courses/Course?id=' + id);
    }

}