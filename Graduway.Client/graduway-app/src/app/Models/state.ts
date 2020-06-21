export interface IState {
  id: number,
  stateDescr: string,
}
class State {
  id: number;
  stateDescr: string;

  constructor(data?: Partial<IState>) {
    this.id = data?.id;
    this.stateDescr = data?.stateDescr;
  }
}

export default State;
