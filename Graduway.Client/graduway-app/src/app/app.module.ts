import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';

//Components
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

//Forms
import { TaskComponent } from './components/dashboard/forms/task/task.component';
import { EmployeeComponent } from './components/dashboard/forms/employee/employee.component';

//Services
import { EmployeesService } from './components/dashboard/services/employees.service';
import { TasksService } from './components/dashboard/services/tasks.service';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    TaskComponent,
    EmployeeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule,
  ],
  providers: [EmployeesService, TasksService],
  bootstrap: [AppComponent],
})
export class AppModule {}
