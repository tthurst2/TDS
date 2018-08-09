using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float rotSpeed = 720f;
    public float maxSpeed = 3.5f;

    float shipBoundaryRadius = 0.5f;

	void Start () {
		
	}
	
	void Update () {
        //rotation removed - ship independently strafes and shoots at mouse
        
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir.Normalize();
        //Rotate towards mouse location
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime); //aim at mouse



        //MOVE THE SHIP
        //Returns a float from -1 to 1
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), maxSpeed * Time.deltaTime * Input.GetAxis("Vertical"), 0);
        pos +=  velocity;
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
