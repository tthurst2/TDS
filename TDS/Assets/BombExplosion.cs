﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour {

    //number of bullets we want in explosive nova
    public float novaBullets = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy() {
        //create big explosion nova
        for(int i = 0; i < (int)novaBullets; i++) {
            Instantiate(Inventory.instance.bullets[0], transform.position, transform.rotation * Quaternion.Euler(0, 0, i * (360f/novaBullets)));
        }
        
    }
}
