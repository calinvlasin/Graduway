import { Component, Output, EventEmitter, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TasksService } from '../../services/tasks.service';
import Task from '../../../../Models/task';
import State from '../../../../Models/state';
import PriorityLevel from '../../../../Models/priorityLevel';
import { title } from 'process';

@Component({
  selector: 'task',
  templateUrl: './task.component.html',
  styleUrls: ['../style/forms.css'],
})
export class TaskComponent implements OnInit {
  @Output() taskSaved = new EventEmitter<boolean>();
  @Input() employeeId: number;
  @Input() taskId: number;
  @Input() isUpdateTask: boolean;

  form: FormGroup;
  task: Task;
  selectedPriority: PriorityLevel;
  selectedState: State;
  formHeaderLabel: string;

  priorityLevels: PriorityLevel[];
  states: State[];

  private _taskService: TasksService;
  private _formBuilder: FormBuilder;
  constructor(taskService: TasksService, formBuilder: FormBuilder) {
    this._taskService = taskService;
    this._formBuilder = formBuilder;
  }

  ngOnInit(): void {
    this.loadPriorityLevels();
    this.loadStates();
    this.loadTask();
    this.buildForm();
  }

  loadPriorityLevels = () => {
    this._taskService.getPriorityLevels().subscribe((priorityLevels) => {
      this.priorityLevels = priorityLevels;
    });
  };

  loadStates = () => {
    this._taskService.getStates().subscribe((states) => {
      this.states = states;
    });
  };

  loadTask() {
    if (this.isUpdateTask) {
      this._taskService.getTaskById(this.taskId).subscribe((task) => {
        this.task = task;
        this.form.patchValue(task);
        this.formHeaderLabel = 'Edit Task';
      });
    } else {
      this.formHeaderLabel = 'Add Task';
    }
  }

  saveTask() {
    if (this.form.valid) {
      let savedTask = new Task(this.form.value);
      if (this.isUpdateTask) {
        savedTask.id = this.task.id;
        this._taskService.updateTask(savedTask).subscribe((isTaskUpdated) => {
          this.taskSaved.emit(isTaskUpdated);
        });
      } else {
        savedTask.employeeId = this.employeeId;
        this._taskService.addTask(savedTask).subscribe((isTaskSaved) => {
          this.taskSaved.emit(isTaskSaved);
        });
      }
    }
  }

  buildForm() {
    this.form = this._formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      estimate: ['', Validators.required],
      stateId: ['', Validators.required],
      priorityLevelId: ['', Validators.required],
    });
  }
}
