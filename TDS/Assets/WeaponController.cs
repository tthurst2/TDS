using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    Inventory inv = Inventory.instance;
    public WeaponManager wm;
    float weaponSwapTimer = 0f;
    public int weaponIndex;
    void Start() {
        wm.LoadWeapons();
        wm.EquipWeapon(0);
    }

    void Update() {
        weaponSwapTimer -= Time.deltaTime;

        //scroll wheel through entire weapon list
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            
            if (weaponIndex >= transform.childCount - 1) {
                weaponIndex = 0;
                wm.EquipWeapon(weaponIndex);
            }
            else {
                weaponIndex++;
                wm.EquipWeapon(weaponIndex);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if (weaponIndex <= 0) {
                weaponIndex = transform.childCount - 1;
                wm.EquipWeapon(weaponIndex);
            }
            else {
                weaponIndex--;
                wm.EquipWeapon(weaponIndex);
            }
        }


        //number keys for first five elements
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponIndex != 0 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 1) {
            weaponIndex = 0;
            wm.EquipWeapon(weaponIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponIndex != 1 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 2) {
            weaponIndex = 1;
            wm.EquipWeapon(weaponIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponIndex != 2 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 3) {
            weaponIndex = 2;
            wm.EquipWeapon(weaponIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && weaponIndex != 3 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 4) {
            weaponIndex = 3;
            wm.EquipWeapon(weaponIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && weaponIndex != 4 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 5) {
            weaponIndex = 4;
            wm.EquipWeapon(weaponIndex);
        }


    }
    
}
