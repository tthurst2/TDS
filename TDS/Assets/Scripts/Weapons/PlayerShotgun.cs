using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotgun : MonoBehaviour, IGunInterface {

    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public float fireDelay = 0.50f;
    float cooldownTimer = 0;
    int bulletLayer;
    float tiltAngle = 15.0f;
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

            Vector3 offset = transform.rotation * bulletOffset;
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            ///two side bullets (shotgun effect)
            GameObject bulletGO2 = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation * Quaternion.Euler(0, 0, tiltAngle));
            GameObject bulletGO3 = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation * Quaternion.Euler(0, 0, -tiltAngle));
            GameObject bulletGO4 = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation * Quaternion.Euler(0, 0, tiltAngle * 2));
            GameObject bulletGO5 = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation * Quaternion.Euler(0, 0, -tiltAngle * 2));
            bulletGO.layer = bulletLayer;
            bulletGO2.layer = bulletLayer;
            bulletGO3.layer = bulletLayer;
            bulletGO4.layer = bulletLayer;
            bulletGO5.layer = bulletLayer;
        }
    }
    public void LoadBullets(int index) {
        bulletPrefab = Inventory.instance.bullets[index];
    }
    #endregion


}
