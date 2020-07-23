using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public float fireDelay = 0.50f;
    float cooldownTimer = 0;
    int bulletLayer;

    Transform player;

    private void Start() {
        bulletLayer = 12; //enemy bullet layer
    }

    void Update() {
        cooldownTimer -= Time.deltaTime;

        if (player == null) {
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null) {
                player = go.transform;
            }
        }

        if (cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 5) {
            //Fire weapon
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGo.layer = bulletLayer;
        }
    }
}
