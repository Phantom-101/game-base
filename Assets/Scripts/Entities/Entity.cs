using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Entity : IEntity {

    [SerializeField] private string _name;
    [SerializeField] private string _identifier;

    [SerializeReference] private IEntity _parent;
    [SerializeReference] private List<IEntity> _children;

    [SerializeReference] private List<IEntityBehaviour> _behaviours;
    private Dictionary<Type, List<IEntityBehaviour>> _typedBehaviours;
    private Dictionary<Type, List<IEntityBehaviour>> _inheritedTypedBehaviours;

    [SerializeReference] private List<IEntityData> _data;
    private Dictionary<Type, List<IEntityData>> _typedData;
    private Dictionary<Type, List<IEntityData>> _inheritedTypedData;

    public Entity () : this ("New Entity") { }

    public Entity (string name) : this (name, Guid.NewGuid ().ToString ()) { }

    public Entity (string name, string identifier) : this (name, identifier, null) { }

    public Entity (string name, IEntity parent) : this (name, Guid.NewGuid ().ToString (), parent) { }

    public Entity (string name, string identifier, IEntity parent) : this (name, identifier, parent, new List<IEntityBehaviour> (), new List<IEntityData> ()) { }

    public Entity (string name, string identifier, List<IEntityBehaviour> behaviours, List<IEntityData> data) : this (name, identifier, null, behaviours, data) { }

    public Entity (string name, string identifier, IEntity parent, List<IEntityBehaviour> behaviours, List<IEntityData> data) {

        _name = name;
        _identifier = identifier;

        _children = new List<IEntity> ();
        SetParent (parent);

        _behaviours = new List<IEntityBehaviour> ();
        _typedBehaviours = new Dictionary<Type, List<IEntityBehaviour>> ();
        _inheritedTypedBehaviours = new Dictionary<Type, List<IEntityBehaviour>> ();

        foreach (IEntityBehaviour b in behaviours) AddBehaviour (b);

        _data = new List<IEntityData> ();
        _typedData = new Dictionary<Type, List<IEntityData>> ();
        _inheritedTypedData = new Dictionary<Type, List<IEntityData>> ();

        foreach (IEntityData d in data) AddData (d);

    }

    public bool AddBehaviour (IEntityBehaviour behaviour) {

        // Get collision modes of the attachment
        List<EntityAttachmentCollisionMode> collisionModes = behaviour.GetAttachmentCollisionModes ();
        // Initialize collision booleans
        bool collidesWithSelf = collisionModes.Contains (EntityAttachmentCollisionMode.Self),
            collidesWithInherited = collisionModes.Contains (EntityAttachmentCollisionMode.Inherited);

        Type t = behaviour.GetType ();

        // Check if the new attachment collides with any existing attachments
        if (collidesWithSelf && _typedBehaviours.GetValueOrDefault (t, new List<IEntityBehaviour> ()).Count > 0) return false;
        if (collidesWithInherited && _inheritedTypedBehaviours.GetValueOrDefault (t, new List<IEntityBehaviour> ()).Count > 0) return false;

        // Add and initialize
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

    public bool AddChild (IEntity child) {

        // If child is already a children
        if (_children.Contains (child)) return false;

        child.GetParent ().RemoveChild (child);
        _children.Add (child);
        child.SetParent (this);
        return true;

    }

    public bool AddData (IEntityData data) {

        // Get collision modes of the attachment
        List<EntityAttachmentCollisionMode> collisionModes = data.GetAttachmentCollisionModes ();
        // Initialize collision booleans
        bool collidesWithSelf = collisionModes.Contains (EntityAttachmentCollisionMode.Self),
            collidesWithInherited = collisionModes.Contains (EntityAttachmentCollisionMode.Inherited);

        Type t = data.GetType ();

        // Check if the new attachment collides with any existing attachments
        if (collidesWithSelf && _typedData.GetValueOrDefault (t, new List<IEntityData> ()).Count > 0) return false;
        if (collidesWithInherited && _inheritedTypedData.GetValueOrDefault (t, new List<IEntityData> ()).Count > 0) return false;

        // Add and initialize
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

        return _behaviours.Count;

    }

    public int CountBehaviours<T> (bool inherited) where T : IEntityBehaviour {

        return GetAllBehaviours<T> (inherited).Count;

    }

    public int CountData () {

        return _data.Count;

    }

    public int CountData<T> (bool inherited) where T : IEntityData {

        return GetAllData<T> (inherited).Count;

    }

    public List<IEntityBehaviour> GetAllBehaviours () {

        return _behaviours;

    }

    public List<IEntityBehaviour> GetAllBehaviours<T> (bool inherited) where T : IEntityBehaviour {

        List<IEntityBehaviour> res = new List<IEntityBehaviour> ();

        if (inherited) res.AddRange (_inheritedTypedBehaviours.GetValueOrDefault (typeof (T), new List<IEntityBehaviour> ()));
        res.AddRange (_typedBehaviours.GetValueOrDefault (typeof (T), new List<IEntityBehaviour> ()));

        return res;

    }

    public List<IEntityData> GetAllData () {

        return _data;

    }

    public List<IEntityData> GetAllData<T> (bool inherited) where T : IEntityData {

        List<IEntityData> res = new List<IEntityData> ();

        if (inherited) res.AddRange (_inheritedTypedData.GetValueOrDefault (typeof (T), new List<IEntityData> ()));
        res.AddRange (_typedData.GetValueOrDefault (typeof (T), new List<IEntityData> ()));

        return res;

    }

    public IEntityBehaviour GetBehaviour<T> (bool inherited) where T : IEntityBehaviour {

        List<IEntityBehaviour> behaviours = GetAllBehaviours<T> (inherited);
        return behaviours.Count == 0 ? null : behaviours[0];

    }

    public IEntityData GetData<T> (bool inherited) where T : IEntityData {

        List<IEntityData> data = GetAllData<T> (inherited);
        return data.Count == 0 ? null : data[0];

    }

    public string GetIdentifier () {

        return _identifier;

    }

    public string GetName () {

        return _name;

    }

    public List<IEntity> GetChildren () {

        return _children;

    }

    public IEntity GetParent () {

        return _parent;

    }

    public bool PossessesBehaviour (IEntityBehaviour behaviour) {

        return _behaviours.Contains (behaviour);

    }

    public bool PossessesBehaviour<T> (bool inherited) where T : IEntityBehaviour {

        return GetAllBehaviours<T> (inherited).Count != 0;

    }

    public bool PossessesData (IEntityData data) {

        return _data.Contains (data);

    }

    public bool PossessesData<T> (bool inherited) where T : IEntityData {

        return GetAllData<T> (inherited).Count != 0;

    }

    public bool RemoveAllBehaviours<T> (bool inherited) where T : IEntityBehaviour {

        List<IEntityBehaviour> toRemove = GetAllBehaviours<T> (inherited);

        if (toRemove.Count == 0) return false;

        bool removed = true;
        foreach (IEntityBehaviour b in toRemove) removed = removed && RemoveBehaviour (b);

        return removed;

    }

    public bool RemoveAllData<T> (bool inherited) where T : IEntityData {

        List<IEntityData> toRemove = GetAllData<T> (inherited);

        if (toRemove.Count == 0) return false;

        bool removed = true;
        foreach (IEntityData d in toRemove) removed = removed && RemoveData (d);

        return removed;

    }

    public bool RemoveBehaviour (IEntityBehaviour behaviour) {

        if (!_behaviours.Contains (behaviour)) return false;

        _behaviours.Remove (behaviour);

        Type t = behaviour.GetType ();
        _typedBehaviours.Initialize (t, new List<IEntityBehaviour> ());
        _typedBehaviours[t].Remove (behaviour);

        while (t.BaseType != null) {
            t = t.BaseType;
            _inheritedTypedBehaviours.Initialize (t, new List<IEntityBehaviour> ());
            _inheritedTypedBehaviours[t].Remove (behaviour);
        }

        return true;

    }

    public bool RemoveBehaviour<T> (bool inherited) where T : IEntityBehaviour {

        return RemoveBehaviour (GetBehaviour<T> (inherited));

    }

    public bool RemoveData (IEntityData data) {

        if (!_data.Contains (data)) return false;

        _data.Remove (data);

        Type t = data.GetType ();
        _typedData.Initialize (t, new List<IEntityData> ());
        _typedData[t].Remove (data);

        while (t.BaseType != null) {
            t = t.BaseType;
            _inheritedTypedData.Initialize (t, new List<IEntityData> ());
            _inheritedTypedData[t].Remove (data);
        }

        return true;

    }

    public bool RemoveData<T> (bool inherited) where T : IEntityData {

        return RemoveData (GetData<T> (inherited));

    }

    public bool RemoveChild (IEntity child) {

        if (!_children.Contains (child)) return false;

        child.SetParent (null);
        return _children.Remove (child);

    }

    public void SetName (string name) {

        _name = name;

    }

    public bool SetParent (IEntity parent) {

        // If target parent is null, set it
        if (parent == null) {

            if (_parent != null) _parent.RemoveChild (this);
            _parent = parent;
            EntityViewer.GetInstance ().AddRootEntity (this);
            return true;

        }

        // If the parent is already its parent, there is no need to set it again
        if (_parent == parent) return false;

        // Checks if any succeeding entities is equal to super
        // If so, return false as to prevent cyclic graphs of entities
        Queue<IEntity> queue = new Queue<IEntity> ();
        queue.Enqueue (this);
        while (queue.Count != 0) {
            IEntity current = queue.Dequeue ();
            if (current == parent) return false;
            foreach (IEntity e in current.GetChildren ()) queue.Enqueue (e);
        }

        // Set parent to parent
        if (_parent != null) _parent.RemoveChild (this);
        _parent = parent;
        _parent.AddChild (this);
        EntityViewer.GetInstance ().RemoveRootEntity (this);
        return true;

    }

}
