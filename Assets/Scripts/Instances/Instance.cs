using System;
using UnityEngine;

public class Instance : Data, IInstance {

    [SerializeField] private Prototype prototype;

    public Prototype GetPrototype () {
        return prototype;
    }

    public Type GetPrototypeType () {
        return typeof (Prototype);
    }

}