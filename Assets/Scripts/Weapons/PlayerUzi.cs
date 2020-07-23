using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUzi : Weapon, IGunInterface {

    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0.45f, 0.25f, 0);
    public float fireDelay = 0.1f;
    float cooldownTimer = 0;
    int bulletLayer;
    //float tiltAngle = 15.0f;
    private void Start() {
        bulletLayer = 11; //player bullet layer

    }

    void Update() {
        cooldownTimer -= Time.deltaTime;
        Fire();
    }
    #region IsGunInterface implementation 
    public void Fire() {

        if (Input.GetButton("Fire1") && cooldownTimer <= 0) {
            //Fire weapon
            cooldownTimer = fireDelay;
            //right wing
            Vector3 offset = transform.rotation * bulletOffset;
            //left wing
            Vector3 offset2 = transform.rotation * new Vector3(-bulletOffset.x, bulletOffset.y, bulletOffset.z);


            //randomzied uzi spread
            GameObject bulletGO  = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation * Quaternion.Euler(0, 0, Random.Range(-30f, 30f)));
            GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab, transform.position + offset2, transform.rotation * Quaternion.Euler(0, 0, Random.Range(-30f, 30f)));
            bulletGO.layer = bulletLayer;
            bulletGO2.layer = bulletLayer;
        }
    }
    public void LoadBullets(int index) {
        bulletPrefab = Inventory.instance.bullets[index];
    }
    public void EquipGun() {

    }

    public void RemoveGun() {

    }
    #endregion


}
