import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WelcomeComponent } from './Components/welcome/welcome.component';
import { CoursesListComponent } from './Components/courses-list/courses-list.component';
import { CourseComponent } from './Components/courses-list/course/course.component';

const appRoutes: Routes = [
  { path: 'index', component: WelcomeComponent },
  { path: 'courses', component: CoursesListComponent },
  { path: 'courses/:id', component: CourseComponent },
  { path: '', redirectTo: 'index', pathMatch: 'full' },
  { path: '**', redirectTo: 'index', pathMatch: 'full' },
];

@NgModule({
  imports:[
    RouterModule.forRoot(appRoutes)
  ],
  exports:[
    // Nas modul 'AppRoutingModule' exportuje konfigurisan RouterModule sa ovim rutama gore
    RouterModule
  ]
})
export class AppRoutingModule{

}