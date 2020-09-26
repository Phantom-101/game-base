using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour, IInitializable {
    
    public Dictionary<GameObject, List<Instance>> GameObjectToInstances;

    [SerializeField] private static InstanceManager singleton;
    [SerializeField] private bool initialized = false;

    void Awake() {
        Initialize();
    }

    public bool CanInitialize() {
        return !initialized;
    }

    public void Initialize() {
        if (!CanInitialize()) return;
        singleton = this;
    }

    public static InstanceManager GetSingleton() {
        return singleton;
    }

}
