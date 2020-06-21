import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import Employee from '../../../Models/employee';

@Injectable()
export class EmployeesService {
  private _http: HttpClient;
  constructor(private http: HttpClient) {
    this._http = http;
  }

  getEmployees(): Observable<Employee[]> {
    return this._http.get<Employee[]>('https://localhost:44313/employees/get');
  }

  addEmployee(employee: Employee): Observable<boolean> {
    return this._http.post<boolean>('https://localhost:44313/employees/add', employee);
  }

  deleteEmployee(employeeId: number): Observable<boolean> {
    return this.http.delete<boolean>(
      `https://localhost:44313/employees/delete-employee?employeeId=${employeeId}`
    );
  }

  getEmployeeById(employeeId: number): Observable<Employee> {
    return this._http.get<Employee>(
      `https://localhost:44313/employees/get-employee?employeeId=${employeeId}`
    );
  }

  updateEmployee(employee: Employee): Observable<boolean> {
    return this._http.put<boolean>(`https://localhost:44313/employees/update-employee`, employee);
  }
}
