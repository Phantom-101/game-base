using System.Collections.Generic;
using UnityEngine;

public class EntityData : IEntityData {

    [SerializeReference] protected IEntity _possessing;

    public bool AttachTo (IEntity entity) {

        if (_possessing == entity) return false;

        if (entity.AddData (this)) {

            _possessing = entity;
            return true;

        }

        return false;

    }

    public virtual bool Collides (IEntityAttachment attachment) {

        return false;

    }

    public virtual List<EntityAttachmentCollisionMode> GetAttachmentCollisionModes () {

        return new List<EntityAttachmentCollisionMode> ();

    }

    public IEntity GetPossessingEntity () {

        return _possessing;

    }

}
