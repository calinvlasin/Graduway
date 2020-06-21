export interface IPriorityLevel {
  id: number,
  priority: string,
}

class PriorityLevel {
  id: number;
  priority: string;

  constructor(data?: Partial<IPriorityLevel>) {
    this.id = data?.id;
    this.priority = data?.priority;
  }
}

export default PriorityLevel;
