using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesPlayer : MonoBehaviour {

    public float rotSpeed = 90f;

    Transform player;


	void Update () {
		if(player == null) {
            GameObject go = GameObject.FindWithTag("Player");

            if(go != null) {
                player = go.transform;
            }
        }

        //Player has been found, or they don't exist right now
        if(player == null) {
            return; // Try again next frame
        }

        //HERE -- we know for sure we have a player. Turn to face it.

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        //assumes x-axis to -90 to make it y-axis
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot,  rotSpeed * Time.deltaTime);
        
	}
}
