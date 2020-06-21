import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { EmployeesService } from './services/employees.service';
import { TasksService } from './services/tasks.service';
import Employee from '../../Models/employee';
import Task from '../../Models/task';
import State from '../../Models/state';
import PriorityLevel from '../../Models/priorityLevel';

@Component({
  selector: 'dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  employees: Employee[];
  tasks: Task[];
  availableStates: State[];
  availablePriorityLevels: PriorityLevel[];

  employeeId: number;
  taskId: number;

  showEmployee: boolean;
  isUpdatedEmployee: boolean;
  showTask: boolean;
  isUpdateTask: boolean;
  showTaskDetails: number;

  private _employeesService: EmployeesService;
  private _tasksService: TasksService;
  constructor(employeesService: EmployeesService, tasksService: TasksService) {
    this._employeesService = employeesService;
    this._tasksService = tasksService;
  }

  ngOnInit() {
    this.loadPriorityLevels();
    this.loadStates();
    this.loadEmployees();
  }

  //#region "Loaders"
  loadPriorityLevels = () => {
    this._tasksService.getPriorityLevels().subscribe((priorityLevels) => {
      this.availablePriorityLevels = priorityLevels;
    });
  };

  loadStates = () => {
    this._tasksService.getStates().subscribe((states) => {
      this.availableStates = states;
    });
  };

  loadEmployees = () => {
    this.getEmployees();
    this.showEmployee = false;
  };

  loadTasks = (employeeId: number) => {
    this.employeeId = employeeId;
    this._tasksService.getTasks(employeeId).subscribe((tasks) => {
      this.tasks = tasks.map((task) => {
        task.stateLabel = this.availableStates.filter(
          (state) => state.id === task.stateId
        )[0].stateDescr;
        task.priorityLevelLabel = this.availablePriorityLevels.filter(
          (priorityLevel) => priorityLevel.id == task.priorityLevelId
        )[0].priority;
        return task;
      });
      this.showTask = false;
    });
  };

  getEmployees = () => {
    this._employeesService.getEmployees().subscribe((employees) => {
      this.employees = employees;
      this.employeeId = employees[0].id;
      this.loadTasks(this.employeeId);
    });
  };
  //#endregion "Loaders"

  //#region "Handlers"
  onTaskClicked(taskId: number) {
    this.showTaskDetails = taskId;
    this.showTask = false;
  }
  onEmployeeClicked = (employeeId: number) => {
    this.loadTasks(employeeId);
  };

  onAddTaskClicked = () => {
    this.isUpdateTask = false;
    this.refreshTaskFormComponent();
  };

  onAddEmployeeClick = () => {
    this.isUpdatedEmployee = false;
    this.refreshEmployeeFormComponent();
  };

  onDeleteTaskClicked = (taskId) => {
    this._tasksService.deleteTask(taskId).subscribe((isTaskDeleted) => {
      if (isTaskDeleted) {
        this.loadTasks(this.employeeId);
      }
    });
  };

  onEditTaskClicked = (taskId) => {
    this.isUpdateTask = true;
    this.taskId = taskId;
    this.refreshTaskFormComponent();
  };

  onEditEmployeeClicked = (employeeId) => {
    this.isUpdatedEmployee = true;
    this.employeeId = employeeId;
    this.refreshEmployeeFormComponent();
  };

  onDeleteEmployeeClicked = (employeeId) => {
    this._employeesService
      .deleteEmployee(employeeId)
      .subscribe((isEmployeeDeleted) => {
        if (isEmployeeDeleted) {
          this.loadEmployees();
        }
      });
  };
  //#endregion Handlers

  //#region "Refreshers"
  private refreshTaskFormComponent() {
    this.showTask = false;
    setTimeout(() => {
      this.showTask = true;
    }, 100);
  }

  private refreshEmployeeFormComponent() {
    this.showEmployee = false;
    setTimeout(() => {
      this.showEmployee = true;
    }, 100);
  }
  //#endregion "Refreshers"
}
