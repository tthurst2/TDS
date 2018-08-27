using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour {

    //number of bullets we want in explosive nova
    public float novaBullets = 45f;
    private bool isQuitting = false;
    private void OnApplicationQuit() {
        isQuitting = true;
    }

    private void OnDestroy() {
        //create big explosion nova

        if (!isQuitting) {
            for (int i = 0; i < (int)novaBullets; i++) {
                if (Inventory.instance != null) {
                    Instantiate(Inventory.instance.bullets[0], transform.position, transform.rotation * Quaternion.Euler(0, 0, i * (360f / novaBullets)));
                }
            }
        }
    }
}
