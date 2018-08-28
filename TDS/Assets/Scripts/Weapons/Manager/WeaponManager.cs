using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    Inventory inv = Inventory.instance;
    float weaponSwapTimer = 0f;
    public int weaponIndex;
    void Start() {
        LoadWeapons();
        EquipWeapon(0);
    }

    void Update() {
        weaponSwapTimer -= Time.deltaTime;

        //scroll wheel through entire weapon list
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if (weaponIndex >= transform.childCount - 1)
                EquipWeapon(0);
            else
                EquipWeapon(weaponIndex + 1);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if (weaponIndex <= 0)
                EquipWeapon(transform.childCount - 1);
            else
                EquipWeapon(weaponIndex - 1);
        }


        //number keys for first five elements
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponIndex != 0 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 1) {
            EquipWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponIndex != 1 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 2) {
            EquipWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponIndex != 2 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 3) {
            EquipWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && weaponIndex != 3 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 4) {
            EquipWeapon(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && weaponIndex != 4 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 5) {
            EquipWeapon(4);
        }

        
    }

    public void LoadWeapons() {
        for(int i = 0; i < inv.weaponList.Count; i++) {
            GameObject go = Instantiate(inv.weaponList[i]);
            go.transform.parent = transform;
            go.SetActive(false);
        }
    }


    public void EquipWeapon(int index) {
        weaponIndex = index;
        int i = 0;
        foreach (Transform weapon in transform) {
            if (i == index)
                weapon.gameObject.SetActive(true);
            else 
                weapon.gameObject.SetActive(false);
                i++;            
        }
    }
}
