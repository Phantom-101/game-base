using UnityEngine;

public class DataAttacher : MonoBehaviour {

    void Awake () {
        DataManager.GetSingleton ().AttachInstance (gameObject, new Instance ());
    }

}
