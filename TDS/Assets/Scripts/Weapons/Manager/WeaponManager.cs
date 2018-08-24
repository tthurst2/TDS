using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    int prevWeapon = -1;
    int currentWeapon = -1;
    float weaponSwapTimer = 0.5f;
	// Use this for initialization
	void Start () {
        IGunInterface gun = gameObject.AddComponent<PlayerBasicBeam>();
        gun.LoadBullets(1);
        //bb.GetComponent<PlayerBasicBeam>().bulletPrefab = Inventory.instance.weapons[0];
        currentWeapon = 0;
        prevWeapon = 0;
    }
	
	// Update is called once per frame
	void Update () {
        /*
         * THIS IS REALLY BAD, DO NOT ACTUALLY USE THIS. PURELY FOR UNDERSTANDING HOW UNITY WORKS
         */
        weaponSwapTimer -= Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Alpha1) && currentWeapon != 0 && weaponSwapTimer <= 0) {
            weaponSwapTimer = 0.5f;
            prevWeapon = currentWeapon;
            DestroyPrevious(prevWeapon);
            currentWeapon = 0;
            //PlayerBasicBeam bb = gameObject.AddComponent<PlayerBasicBeam>();
            IGunInterface gun = gameObject.AddComponent<PlayerBasicBeam>();
            gun.LoadBullets(0);
            //bb.bulletPrefab = Resources.Load<GameObject>("Prefabs/Weapons/Blue Beam");
            //bb.bulletPrefab = Inventory.instance.bullets[0];
        }

        if (Input.GetKey(KeyCode.Alpha2) && currentWeapon != 1 && weaponSwapTimer <= 0) {
            weaponSwapTimer = 0.5f; ;
            prevWeapon = currentWeapon;
            DestroyPrevious(prevWeapon);
            currentWeapon = 1;
            IGunInterface gun = gameObject.AddComponent<PlayerShotgun>();
            gun.LoadBullets(1);
            //PlayerShotgun ps = gameObject.AddComponent<PlayerShotgun>();
            //ps.bulletPrefab = Inventory.instance.bullets[1];
        }

        if (Input.GetKey(KeyCode.Alpha3) && currentWeapon != 2 && weaponSwapTimer <= 0) {
            weaponSwapTimer = 0.5f; ;
            prevWeapon = currentWeapon;
            DestroyPrevious(prevWeapon);
            currentWeapon = 2;
            IGunInterface gun = gameObject.AddComponent<PlayerUzi>();
            gun.LoadBullets(2);
            //PlayerUzi pu = gameObject.AddComponent<PlayerUzi>();
            //pu.bulletPrefab = Inventory.instance.bullets[2];
        }

    }

    public void DestroyPrevious(int index) {
        switch (index) {
            case 0:
                PlayerBasicBeam bb = GetComponent<PlayerBasicBeam>();
                Destroy(bb);
                break;
            case 1:
                PlayerShotgun ps = GetComponent<PlayerShotgun>();
                Destroy(ps);
                break;
            case 2:
                PlayerUzi pu = GetComponent<PlayerUzi>();
                Destroy(pu);
                break;
            default:
                Debug.Log("Error with weapon destruction");
                break;
        }

    }    

}
