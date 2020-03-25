import { ModelBase } from '@otmodel/model-base';


export class ActionAttribute extends ModelBase {

  public Name = '';
  public Value: any;

  constructor( ) {
    super();
  }

  getId(): number {
    return 0;
  }
  setId(id: number) {

  }
}
