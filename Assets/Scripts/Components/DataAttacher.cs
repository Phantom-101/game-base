using UnityEngine;

public class DataAttacher : MonoBehaviour {

    void Awake () {
        DataManager.GetSingleton ().AttachInstance (gameObject, new Instance ());
        DataManager.GetSingleton ().AttachInstance (gameObject, new Data ());
    }

}
