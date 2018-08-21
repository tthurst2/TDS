using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUzi : MonoBehaviour, IGunInterface {

    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public float fireDelay = 0.1f;
    float cooldownTimer = 0;
    int bulletLayer;
    //float tiltAngle = 15.0f;
    private void Start() {
        bulletLayer = 11; //player bullet layer

    }

    void Update() {
        Fire();
    }
    #region IsGunInterface implementation 
    public void Fire() {
        cooldownTimer -= Time.deltaTime;


        if (Input.GetButton("Fire1") && cooldownTimer <= 0) {
            //Fire weapon
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            //randomzied uzi spread
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation * Quaternion.Euler(0, 0, Random.Range(-30f, 30f)));
            bulletGO.layer = bulletLayer;
        }
    }
    #endregion


}
