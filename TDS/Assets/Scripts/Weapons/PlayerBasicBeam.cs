using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicBeam : MonoBehaviour, IGunInterface {

    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    int bulletLayer;

    private void Start() {
        bulletLayer = 11; //player bullet layer
        Inventory.instance.Add(this);
        LoadBullets(0);
    }

    void Update() {
        cooldownTimer -= Time.deltaTime;
        //Fire();
    }
    public void Fire() {
        
        if (Input.GetButton("Fire1") && cooldownTimer <= 0) {
            //Fire weapon
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
    public void LoadBullets(int index) {
        bulletPrefab = Inventory.instance.bullets[index];
    }
    public void EquipGun() {
        Debug.Log("equipping PlayerBasicLaser");
        transform.parent.gameObject.AddComponent<PlayerBasicBeam>();
    }

    public void RemoveGun() {

    }

}
