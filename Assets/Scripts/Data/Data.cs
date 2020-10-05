using System;
using UnityEngine;

public class Data : IIdentifiable, IData {

    [SerializeField] private string identifier;

    public string GetIdentifier () {
        return identifier;
    }

    public string InitializeIdentifier () {
        identifier = new Guid ().ToString ();
        return identifier;
    }

    public Data GetData () {
        return this;
    }

}