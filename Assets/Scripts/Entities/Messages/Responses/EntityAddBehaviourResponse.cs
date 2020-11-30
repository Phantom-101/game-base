using System;
using System.Collections.Generic;

[Obsolete ("This message is no longer used.")]
public struct EntityAddBehaviourResponse {

    public IEntity Entity;
    public IEntityBehaviour Behaviour;
    public bool Added;
    public List<IEntityBehaviour> Result;

}
