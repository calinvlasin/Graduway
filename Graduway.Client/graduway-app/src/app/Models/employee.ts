import Task from './task';

export interface IEmployee {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  department: string;
  tasks: Task[];
  title: string;
}

class Employee {
  id: number;
  firstName: string;
  lastName: string;
  address: string;
  department: string;
  tasks: Task[];
  title: string;

  constructor(data?: Partial<IEmployee>) {
    this.id = data?.id;
    this.firstName = data?.firstName;
    this.lastName = data?.lastName;
    this.address = data?.address;
    this.department = data?.department;
    this.tasks = data?.tasks;
    this.title = data?.title;
  }
}

export default Employee;
