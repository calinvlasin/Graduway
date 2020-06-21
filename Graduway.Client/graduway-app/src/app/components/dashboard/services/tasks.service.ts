import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import Task from '../../../Models/task';
import State from '../../../Models/state';
import PriorityLevel from '../../../Models/priorityLevel';

@Injectable()
export class TasksService {
  private _http: HttpClient;
  constructor(private http: HttpClient) {
    this._http = http;
  }

  getTasks(employeeId: number): Observable<Task[]> {
    return this._http.get<Task[]>(
      `https://localhost:44313/tasks/get?employeeId=${employeeId}`
    );
  }

  addTask(task: Task): Observable<boolean> {
    return this._http.post<boolean>('https://localhost:44313/tasks/add', task);
  }

  getPriorityLevels(): Observable<PriorityLevel[]> {
    return this.http.get<PriorityLevel[]>(
      'https://localhost:44313/tasks/priority-levels'
    );
  }

  getStates(): Observable<State[]> {
    return this.http.get<State[]>('https://localhost:44313/tasks/states');
  }

  deleteTask(taskId: number): Observable<boolean> {
    return this.http.delete<boolean>(
      `https://localhost:44313/tasks/delete?taskId=${taskId}`
    );
  }

  getTaskById(taskId: number): Observable<Task> {
    return this._http.get<Task>(
      `https://localhost:44313/tasks/get-task?taskId=${taskId}`
    );
  }

  updateTask(task: Task): Observable<boolean> {
    return this._http.put<boolean>(`https://localhost:44313/tasks/update`, task);
  }
}
