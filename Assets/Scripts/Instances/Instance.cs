using System;
using UnityEngine;

public class Instance : Data, IInstance {

    [SerializeField] private Prototype prototype;

    public Instance () {
        prototype = null;
    }

    public Instance (Prototype prototype) {
        this.prototype = prototype;
    }

    public virtual Prototype GetPrototype () {
        return prototype;
    }

    public virtual Type GetPrototypeType () {
        return typeof (Prototype);
    }

}