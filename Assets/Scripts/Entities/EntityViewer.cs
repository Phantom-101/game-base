using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityViewer : MonoBehaviour {

    [SerializeReference] private List<IEntity> _roots;

    private static EntityViewer _instance;

    private void Awake () {

        if (_instance == null) _instance = this;
        else Destroy (this);

    }

    private void Start () {
        Entity root = new Entity ("A");
        new Entity ("B", root);
    }

    public static EntityViewer GetInstance () {

        return _instance;

    }

    public bool AddRootEntity (IEntity entity) {

        if (_roots.Contains (entity)) return false;
        if (entity.GetSuperEntity () != null) return false;

        _roots.Add (entity);
        return true;

    }

    public bool RemoveRootEntity (IEntity entity) {

        return _roots.Remove (entity);

    }

}
