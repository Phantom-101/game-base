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

    public List<Data> GetData<T> (GameObject gameObject) {
        List<Data> data = GetData (gameObject);
        List<Data> ret = new List<Data> ();

        foreach (Data d in data)
            if (d.GetType () == typeof (T) || d.GetType ().IsSubclassOf (typeof (T)))
                ret.Add (d);

        return ret;
    }

    public List<Data> GetData<T> () {
        List<Data> ret = new List<Data> ();

        foreach (Type type in TypeToData.Keys)
            if (type == typeof (T) || type.IsSubclassOf (typeof (T)))
                ret.AddRange (TypeToData[type]);

        return ret;
    }

    public void AttachInstance (GameObject gameObject, Data data) {
        TryInitializeDictionaryEntry (gameObject);
        GameObjectToData[gameObject].Add (data);

        TryInitializeDictionaryEntry (data.GetType ());
        TypeToData[data.GetType ()].Add (data);
    }

    public void DetachInstance (GameObject gameObject, Data data) {
        TryInitializeDictionaryEntry (gameObject);
        GameObjectToData[gameObject].Remove (data);

        TryInitializeDictionaryEntry (data.GetType ());
        TypeToData[data.GetType ()].Remove (data);
    }

    void TryInitializeDictionaryEntry (GameObject gameObject) {
        if (!GameObjectToData.ContainsKey (gameObject)) GameObjectToData[gameObject] = new List<Data> ();
    }

    void TryInitializeDictionaryEntry (Type type) {
        if (!TypeToData.ContainsKey (type)) TypeToData[type] = new List<Data> ();
    }

}
