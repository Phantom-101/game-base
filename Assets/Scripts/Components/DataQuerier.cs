using UnityEngine;

public class DataQuerier : MonoBehaviour {

    void Update () {
        Debug.Log (DataManager.GetSingleton ().GetData<Instance> (gameObject).Count);
        Debug.Log (DataManager.GetSingleton ().GetData<Data> (gameObject).Count);
    }

}
