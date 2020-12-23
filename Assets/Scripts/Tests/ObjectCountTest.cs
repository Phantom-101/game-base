using UnityEngine;

public class ObjectCountTest : Test {

    [SerializeField] private int _count;

    private void Start () {

        for (int i = 0; i < _count; i++) {

            if (_testMode == TestMode.GameObject) new GameObject (i.ToString ());
            else new Entity (i.ToString ());

        }

    }

}
