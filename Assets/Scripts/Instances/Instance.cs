using System;
using UnityEngine;

public class Instance : IIdentifiable, IInstance {

    [SerializeField] private Prototype prototype;

    [SerializeField] private string identifier;

    public string GetIdentifier () {
        return identifier;
    }

    public string InitializeIdentifier () {
        identifier = new Guid ().ToString ();
        return identifier;
    }

    public Prototype GetPrototype () {
        return prototype;
    }

    public Type GetPrototypeType () {
        return typeof (Prototype);
    }

}