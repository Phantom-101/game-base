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
        Entity a = new Entity ("A");
        Entity b = new Entity ("B", a);
        Entity c = new Entity ("C", b);
        Entity d = new Entity ("D", a);
    }

    public static EntityViewer GetInstance () {

        return _instance;

    }

    public bool AddRootEntity (IEntity entity) {

        if (_roots.Contains (entity)) return false;
        if (entity.GetParent () != null) return false;

        _roots.Add (entity);
        return true;

    }

    public bool RemoveRootEntity (IEntity entity) {

        return _roots.Remove (entity);

    }

}
