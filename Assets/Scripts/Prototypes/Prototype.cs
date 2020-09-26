using System;
using UnityEngine;

public class Prototype : IIdentifiable, IPrototype {

    [SerializeField] private string identifier;

    public string GetIdentifier() {
        return identifier;
    }

    public string InitializeIdentifier() {
        identifier = new Guid().ToString();
        return identifier;
    }

    public Instance GetInstance() {
        return new Instance();
    }

    public Type GetInstanceType() {
        return typeof(Instance);
    }

}