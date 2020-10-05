using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IInitializable {

    public Dictionary<GameObject, List<Data>> GameObjectToData;
    public Dictionary<Type, List<Data>> TypeToData;

    [SerializeField] private static DataManager singleton;
    [SerializeField] private bool initialized = false;

    public bool CanInitialize () {
        return !initialized;
    }

    public void Initialize () {
        if (!CanInitialize ()) return;

        singleton = this;

        GameObjectToData = new Dictionary<GameObject, List<Data>> ();
        TypeToData = new Dictionary<Type, List<Data>> ();

        initialized = true;
    }

    public static DataManager GetSingleton () {
        if (singleton == null) {
            singleton = new DataManager ();
            singleton.Initialize ();
        }

        return singleton;
    }

    public List<Data> GetData (GameObject gameObject) {
        GameObjectToData.TryGetValue (gameObject, out List<Data> ret);
        return ret;
    }

    public List<Data> GetData (Type type) {
        TypeToData.TryGetValue (type, out List<Data> ret);
        return ret;
    }

    public void AttachInstance (GameObject gameObject, Data data) {
        if (!GameObjectToData.ContainsKey (gameObject)) GameObjectToData[gameObject] = new List<Data> ();
        GameObjectToData[gameObject].Add (data);

        if (!TypeToData.ContainsKey (data.GetType ())) TypeToData[data.GetType ()] = new List<Data> ();
        TypeToData[data.GetType ()].Add (data);
    }

    public void DetachInstance (GameObject gameObject, Data data) {
        if (!GameObjectToData.ContainsKey (gameObject)) GameObjectToData[gameObject] = new List<Data> ();
        GameObjectToData[gameObject].Remove (data);

        if (!TypeToData.ContainsKey (data.GetType ())) TypeToData[data.GetType ()] = new List<Data> ();
        TypeToData[data.GetType ()].Remove (data);
    }

}
