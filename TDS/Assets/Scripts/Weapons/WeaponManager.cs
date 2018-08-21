using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    string prevWeapon;
    string currentWeapon = "PlayerBasicBeam";
	// Use this for initialization
	void Start () {
        PlayerBasicBeam bb = gameObject.AddComponent<PlayerBasicBeam>();
        bb.bulletPrefab = Resources.Load<GameObject>("Prefabs/Weapons/Blue Beam");
    }
	
	// Update is called once per frame
	void Update () {
        /*
         * THIS IS REALLY BAD, DO NOT ACTUALLY USE THIS. PURELY FOR UNDERSTANDING HOW UNITY WORKS
         */
        if (Input.GetKey(KeyCode.Alpha1) && currentWeapon != "PlayerBasicBeam") {
            PlayerShotgun ps = GetComponent<PlayerShotgun>();
            Destroy(ps);
            prevWeapon = currentWeapon;
            currentWeapon = "PlayerBasicBeam";
            PlayerBasicBeam bb = gameObject.AddComponent<PlayerBasicBeam>();
            bb.bulletPrefab = Resources.Load<GameObject>("Prefabs/Weapons/Blue Beam");
        }

        if (Input.GetKey(KeyCode.Alpha2) && currentWeapon != "PlayerShotgun") {
            PlayerBasicBeam bb = GetComponent<PlayerBasicBeam>();
            Destroy(bb);
            prevWeapon = currentWeapon;
            currentWeapon = "PlayerShotgun";
            PlayerShotgun ps = gameObject.AddComponent<PlayerShotgun>();
            ps.bulletPrefab = Resources.Load<GameObject>("Prefabs/Weapons/Red Shotgun");
        }
	}
}
