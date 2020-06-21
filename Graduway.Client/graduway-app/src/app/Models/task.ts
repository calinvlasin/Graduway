export interface ITask {
  id: number;
  title: string;
  description: string;
  estimate: number;
  employeeId: number;
  priorityLevelId: number;
  stateId: number;
  priorityLevelLabel: string;
  stateLabel: string;
}
class Task {
  id?: number;
  title: string;
  description: string;
  employeeId: number;
  priorityLevelId: number;
  stateId: number;
  estimate: number;
  priorityLevelLabel: string;
  stateLabel: string;

  constructor(data?: Partial<ITask>) {
    this.id = data?.id;
    this.title = data?.title;
    this.description = data?.description;
    this.employeeId = data?.employeeId;
    this.priorityLevelId = data?.priorityLevelId;
    this.stateId = data?.stateId;
    this.estimate = data?.estimate;
    this.priorityLevelLabel = data?.priorityLevelLabel;
    this.stateLabel = data?.stateLabel;
  }
}

export default Task;
