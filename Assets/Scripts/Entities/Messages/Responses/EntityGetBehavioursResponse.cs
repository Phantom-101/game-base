using System;
using System.Collections.Generic;

[Obsolete ("This message is no longer used.")]
public struct EntityGetBehavioursResponse {

    public IEntity Entity;
    public List<IEntityBehaviour> Behaviours;

    public EntityGetBehavioursResponse (IEntity entity, List<IEntityBehaviour> behaviours) {
        Entity = entity;
        Behaviours = behaviours;
    }

}
