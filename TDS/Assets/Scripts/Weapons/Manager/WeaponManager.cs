using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    int prevWeapon = -1;
    int currentWeapon = -1;
	// Use this for initialization
	void Start () {
        PlayerBasicBeam bb = gameObject.AddComponent<PlayerBasicBeam>();
        bb.bulletPrefab = Resources.Load<GameObject>("Prefabs/Weapons/Blue Beam");
        currentWeapon = 0;
        prevWeapon = 0;
    }
	
	// Update is called once per frame
	void Update () {
        /*
         * THIS IS REALLY BAD, DO NOT ACTUALLY USE THIS. PURELY FOR UNDERSTANDING HOW UNITY WORKS
         */
        if (Input.GetKey(KeyCode.Alpha1) && currentWeapon != 0) {
            prevWeapon = currentWeapon;
            DestroyPrevious(prevWeapon);
            currentWeapon = 0;
            PlayerBasicBeam bb = gameObject.AddComponent<PlayerBasicBeam>();
            bb.bulletPrefab = Resources.Load<GameObject>("Prefabs/Weapons/Blue Beam");
        }

        if (Input.GetKey(KeyCode.Alpha2) && currentWeapon != 1) {
            prevWeapon = currentWeapon;
            DestroyPrevious(prevWeapon);
            currentWeapon = 1;
            PlayerShotgun ps = gameObject.AddComponent<PlayerShotgun>();
            ps.bulletPrefab = Resources.Load<GameObject>("Prefabs/Weapons/Red Shotgun");
        }

        if (Input.GetKey(KeyCode.Alpha3) && currentWeapon != 2) {
            prevWeapon = currentWeapon;
            DestroyPrevious(prevWeapon);
            currentWeapon = 2;
            PlayerUzi pu = gameObject.AddComponent<PlayerUzi>();
            pu.bulletPrefab = Resources.Load<GameObject>("Prefabs/Weapons/Green Uzi");
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
