using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EntityViewer : MonoBehaviour {

    [SerializeReference] private List<IEntity> _roots;

    private static EntityViewer _instance;

    private void Awake () {

        if (_instance == null) _instance = this;
        else Destroy (this);

    }

    public static EntityViewer GetInstance () {

        return _instance;

    }

    public void UpdateRoots () {

        EntityList list = EntityList.GetInstance ();
        if (list == null) return;

        _roots = new List<IEntity> ();

        foreach (IEntity entity in list.GetEntities ()) {

            if (entity.GetParent () == null) _roots.Add (entity);

        }

    }

}

[CustomEditor (typeof (EntityViewer))]
public class EntityViewerEditor : Editor {

    public override void OnInspectorGUI () {

        base.OnInspectorGUI ();

        EntityViewer viewer = target as EntityViewer;

        if (GUILayout.Button ("Update Roots")) viewer.UpdateRoots ();

    }

}