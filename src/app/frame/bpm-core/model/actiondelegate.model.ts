import { ModelBase } from '@otmodel/model-base';

export class ActionDelegate extends ModelBase {

  public ActionId = 0;
  public Group = 0;
  public User = 0;
  public ActivityName = '';
  public ProcessDefinitionName = '';
  public Comment: '';

  constructor( ) {
    super();
  }

  getId(): number {
    return 0;
  }
  setId(id: number) {

  }
}
