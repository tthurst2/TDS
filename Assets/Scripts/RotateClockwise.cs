using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClockwise : MonoBehaviour {

    public float zAngle =  720f;

    void Update() {
        transform.Rotate(0, 0, Time.deltaTime * 120, Space.Self);

    }
}
