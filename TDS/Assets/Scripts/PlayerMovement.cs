using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float rotSpeed = 180f;
    public float maxSpeed = 3.5f;

    float shipBoundaryRadius = 0.5f;

	void Start () {
		
	}
	
	void Update () {

        //ROTATE THE SHIP
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        //Take horizontal input, times rotation speed and delta time and add them to the euler transform of the transform's rotation Z-axis.
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //MOVE THE SHIP
        //Returns a float from -1 to 1
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime * Input.GetAxis("Vertical"), 0);
        pos += rot * velocity;
        transform.position = pos;

        // RESTRICT SHIP TO CAMERA
        //y-coord
        if(pos.y + shipBoundaryRadius > Camera.main.orthographicSize) {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        float screenRatio = (float)Screen.width / Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        //x-coord
        if(pos.x + shipBoundaryRadius > widthOrtho) {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if(pos.x - shipBoundaryRadius < -widthOrtho) {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }
        transform.position = pos;

    }
}
