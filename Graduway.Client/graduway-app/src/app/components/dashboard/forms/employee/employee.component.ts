import { Component, Output, EventEmitter, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeesService } from '../../services/employees.service';
import Employee from '../../../../Models/employee';

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html',
  styleUrls: ['../style/forms.css'],
})
export class EmployeeComponent implements OnInit {
  @Output() employeeSaved = new EventEmitter<boolean>();
  @Input() employeeId: number;
  @Input() isUpdatedEmployee: boolean;

  form: FormGroup;
  employee: Employee;
  formHeaderLabel: string;

  private _employeeService: EmployeesService;
  private _formBuilder: FormBuilder;
  constructor(employeeService: EmployeesService, formBuilder: FormBuilder) {
    this._employeeService = employeeService;
    this._formBuilder = formBuilder;
  }

  ngOnInit(): void {
    this.loadEmployees();
    this.buildForm();
  }

  loadEmployees() {
    if (this.isUpdatedEmployee) {
      this._employeeService.getEmployeeById(this.employeeId).subscribe((employee) => {
        this.employee = employee;
        this.form.patchValue(employee);
        this.formHeaderLabel = 'Edit Employee';
      });
    } else {
      this.formHeaderLabel = 'Add Employee';
    }
  }

  saveEmployee() {
    if (this.form.valid) {
      let savedEmployee = new Employee(this.form.value);
      if (this.isUpdatedEmployee) {
        savedEmployee.id = this.employee.id;
        this._employeeService.updateEmployee(savedEmployee).subscribe((isEmployeeUpdated) => {
          this.employeeSaved.emit(isEmployeeUpdated);
        });
      } else {
        savedEmployee.id = this.employeeId;
        this._employeeService.addEmployee(savedEmployee).subscribe((isEmployeeSaved) => {
          this.employeeSaved.emit(isEmployeeSaved);
        });
      }
    }
  }

  buildForm() {
    this.form = this._formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      title: ['', Validators.required],
      department: ['', Validators.required],
      address: ['', Validators.required],
    });
  }
}
