using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IInitializable {

    public Dictionary<GameObject, List<Data>> GameObjectToData;
    public Dictionary<GameObject, Dictionary<Type, List<Data>>> GameObjectToTypeToData;
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
        GameObjectToTypeToData = new Dictionary<GameObject, Dictionary<Type, List<Data>>> ();
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
        TryInitializeDictionaryEntry (gameObject);

        return GameObjectToData[gameObject];
    }

    public List<Data> GetData<T> (GameObject gameObject) {
        Type type = typeof (T);

        TryInitializeDictionaryEntry (gameObject, type);

        return GameObjectToTypeToData[gameObject][type];
    }

    public List<Data> GetData (GameObject gameObject, Type type) {
        TryInitializeDictionaryEntry (gameObject, type);

        return GameObjectToTypeToData[gameObject][type];
    }

    public List<Data> GetData<T> () {
        Type type = typeof (T);

        TryInitializeDictionaryEntry (type);

        return TypeToData[type];
    }

    public List<Data> GetData (Type type) {
        TryInitializeDictionaryEntry (type);

        return TypeToData[type];
    }

    public void AttachInstance (GameObject gameObject, Data data) {
        TryInitializeDictionaryEntry (gameObject);
        GameObjectToData[gameObject].Add (data);

        Type t = data.GetType ();
        while (t != null) {
            TryInitializeDictionaryEntry (gameObject, t);
            GameObjectToTypeToData[gameObject][t].Add (data);

            TryInitializeDictionaryEntry (t);
            TypeToData[t].Add (data);

            t = t.BaseType;
        }
    }

    public void DetachInstance (GameObject gameObject, Data data) {
        TryInitializeDictionaryEntry (gameObject);
        GameObjectToData[gameObject].Remove (data);

        Type t = data.GetType ();
        while (t != null) {
            TryInitializeDictionaryEntry (gameObject, t);
            GameObjectToTypeToData[gameObject][t].Remove (data);

            TryInitializeDictionaryEntry (t);
            TypeToData[t].Remove (data);

            t = t.BaseType;
        }
    }

    void TryInitializeDictionaryEntry (GameObject gameObject) {
        if (!GameObjectToData.ContainsKey (gameObject)) GameObjectToData[gameObject] = new List<Data> ();
        if (!GameObjectToTypeToData.ContainsKey (gameObject)) GameObjectToTypeToData[gameObject] = new Dictionary<Type, List<Data>> ();
    }

    void TryInitializeDictionaryEntry (GameObject gameObject, Type type) {
        TryInitializeDictionaryEntry (gameObject);
        if (!GameObjectToTypeToData[gameObject].ContainsKey (type)) GameObjectToTypeToData[gameObject][type] = new List<Data> ();
    }

    void TryInitializeDictionaryEntry (Type type) {
        if (!TypeToData.ContainsKey (type)) TypeToData[type] = new List<Data> ();
    }

}
