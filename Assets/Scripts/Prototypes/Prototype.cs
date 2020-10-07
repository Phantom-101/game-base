using System;
using UnityEngine;

public class Prototype : Data, IIdentifiable, IPrototype {

    public virtual Instance GetInstance () {
        return new Instance ();
    }

    public virtual Type GetInstanceType () {
        return typeof (Instance);
    }

}