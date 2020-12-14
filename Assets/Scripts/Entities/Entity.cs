using System;
using System.Collections.Generic;

public class Entity : IEntity {

    private List<IEntityBehaviour> _behaviours;
    private Dictionary<Type, List<IEntityBehaviour>> _typedBehaviours;
    private Dictionary<Type, List<IEntityBehaviour>> _inheritedTypedBehaviours;

    private List<IEntityData> _data;
    private Dictionary<Type, List<IEntityData>> _typedData;
    private Dictionary<Type, List<IEntityData>> _inheritedTypedData;

    public Entity () {

        _behaviours = new List<IEntityBehaviour> ();
        _typedBehaviours = new Dictionary<Type, List<IEntityBehaviour>> ();
        _inheritedTypedBehaviours = new Dictionary<Type, List<IEntityBehaviour>> ();

        _data = new List<IEntityData> ();
        _typedData = new Dictionary<Type, List<IEntityData>> ();
        _inheritedTypedData = new Dictionary<Type, List<IEntityData>> ();

    }

    public bool AddBehaviour (IEntityBehaviour behaviour) {

        List<EntityAttachmentCollisionMode> collisionModes = behaviour.GetAttachmentCollisionModes ();
        bool collidesWithSelf = collisionModes.Contains (EntityAttachmentCollisionMode.Self),
            collidesWithInherited = collisionModes.Contains (EntityAttachmentCollisionMode.Inherited);

        Type t = behaviour.GetType ();

        if (collidesWithSelf && _typedBehaviours.GetValueOrDefault (t, new List<IEntityBehaviour> ()).Count > 0) return false;
        if (collidesWithInherited && _inheritedTypedBehaviours.GetValueOrDefault (t, new List<IEntityBehaviour> ()).Count > 0) return false;

        _behaviours.Add (behaviour);
        _typedBehaviours.Initialize (t, new List<IEntityBehaviour> ());
        _typedBehaviours[t].Add (behaviour);
        Type cur = t;
        while (cur.BaseType != null) {
            cur = cur.BaseType;
            _inheritedTypedBehaviours.Initialize (cur, new List<IEntityBehaviour> ());
            _inheritedTypedBehaviours[cur].Add (behaviour);
        }

        return true;

    }

    public bool AddBehaviour<T> () where T : IEntityBehaviour {

        return AddBehaviour (Activator.CreateInstance<T> ());

    }

    public bool AddData (IEntityData data) {

        List<EntityAttachmentCollisionMode> collisionModes = data.GetAttachmentCollisionModes ();
        bool collidesWithSelf = collisionModes.Contains (EntityAttachmentCollisionMode.Self),
            collidesWithInherited = collisionModes.Contains (EntityAttachmentCollisionMode.Inherited);

        Type t = data.GetType ();

        if (collidesWithSelf && _typedData.GetValueOrDefault (t, new List<IEntityData> ()).Count > 0) return false;
        if (collidesWithInherited && _inheritedTypedData.GetValueOrDefault (t, new List<IEntityData> ()).Count > 0) return false;

        _data.Add (data);
        _typedData.Initialize (t, new List<IEntityData> ());
        _typedData[t].Add (data);
        Type cur = t;
        while (cur.BaseType != null) {
            cur = cur.BaseType;
            _inheritedTypedData.Initialize (cur, new List<IEntityData> ());
            _inheritedTypedData[cur].Add (data);
        }

        return true;

    }

    public bool AddData<T> () where T : IEntityData {

        return AddData (Activator.CreateInstance<T> ());

    }

    public int CountBehaviours () {
        throw new System.NotImplementedException ();
    }

    public int CountBehaviours<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public int CountData () {
        throw new System.NotImplementedException ();
    }

    public int CountData<T> () {
        throw new System.NotImplementedException ();
    }

    public List<IEntityBehaviour> GetAllBehaviours () {
        throw new System.NotImplementedException ();
    }

    public List<IEntityBehaviour> GetAllBehaviours<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public List<IEntityData> GetAllData () {
        throw new System.NotImplementedException ();
    }

    public List<IEntityData> GetAllData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public IEntityBehaviour GetBehaviour<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public IEntityData GetData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public string GetIdentifier () {
        throw new System.NotImplementedException ();
    }

    public string GetName () {
        throw new System.NotImplementedException ();
    }

    public List<IEntity> GetSubEntities () {
        throw new System.NotImplementedException ();
    }

    public IEntity GetSuperEntity () {
        throw new System.NotImplementedException ();
    }

    public bool PossessesBehaviour (IEntityBehaviour behaviour) {
        throw new System.NotImplementedException ();
    }

    public bool PossessesBehaviour<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool PossessesData (IEntityData data) {
        throw new System.NotImplementedException ();
    }

    public bool PossessesData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveAllBehaviours<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveAllData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveBehaviour (IEntityBehaviour behaviour) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveBehaviour<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveData (IEntityData data) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

}
