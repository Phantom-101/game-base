using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityList : MonoBehaviour {

    private List<IEntity> _entities;

    private static EntityList _instance;

    private void Awake () {

        if (_instance == null) _instance = this;
        else Destroy (this);

    }

    public static EntityList GetInstance () {

        return _instance;

    }

    public List<IEntity> GetEntities () {

        _entities = _entities.Distinct ().ToList ();
        return new List<IEntity> (_entities);

    }

    public void AddEntity (IEntity entity) {

        _entities.Add (entity);

    }

    public void RemoveEntity (IEntity entity) {

        _entities.Remove (entity);

    }

}
