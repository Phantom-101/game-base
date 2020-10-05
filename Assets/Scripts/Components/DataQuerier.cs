using UnityEngine;

public class DataQuerier : MonoBehaviour {

    void Update () {
        Debug.Log (DataManager.GetSingleton ().GetData (gameObject).Count);
    }

}
