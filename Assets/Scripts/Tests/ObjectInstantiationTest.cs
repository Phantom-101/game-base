using UnityEngine;

public class ObjectInstantiationTest : Test {

    [SerializeField] private int _countPerFrame;

    private void Update () {

        for (int i = 0; i < _countPerFrame; i++) {

            if (_testMode == TestMode.GameObject) new GameObject (i.ToString ());
            else new Entity (i.ToString ());

        }

    }

}
