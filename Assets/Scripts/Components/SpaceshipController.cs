using UnityEngine;

public class SpaceshipController : MonoBehaviour {

    private ConstantForce cf;

    void Awake () {
        cf = GetComponent<ConstantForce> ();
    }

    void Update () {
        cf.relativeForce = new Vector3 (
            0,
            0,
            Input.GetAxis ("Vertical")
        );

        cf.relativeTorque = new Vector3 (
            -Input.GetAxis ("Vertical Movement"),
            Input.GetAxis ("Horizontal"),
            0
        );
    }

}
