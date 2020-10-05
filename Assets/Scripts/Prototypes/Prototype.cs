using System;
using UnityEngine;

public class Prototype : IIdentifiable, IPrototype {

    [SerializeField] private string identifier;

    public string GetIdentifier () {
        return identifier;
    }

    public string InitializeIdentifier () {
        identifier = new Guid ().ToString ();
        return identifier;
    }

    public virtual Instance GetInstance () {
        return new Instance ();
    }

    public virtual Type GetInstanceType () {
        return typeof (Instance);
    }

}