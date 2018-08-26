using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
    float weaponSwapTimer = 0f;
    public GameObject equippedWeapon;
    public int index = 0;
    private readonly Inventory inv = Inventory.instance;
    // Use this for initialization
    void Start() {
        equippedWeapon = inv.weaponList[0];
        index = inv.weaponList.IndexOf(equippedWeapon);
    }

    // Update is called once per frame
    void Update() {

        weaponSwapTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha1) && index != 0 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 1) {
            SetWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && index != 1 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 2) {
            SetWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && index != 2 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 3) {
            SetWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && index != 3 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 4) {
            SetWeapon(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && index != 4 && weaponSwapTimer <= 0 && inv.weaponList.Count >= 5) {
            SetWeapon(4);
        }
    }
    void SetWeapon(int i) {
        weaponSwapTimer = 0.50f;
        equippedWeapon = inv.weaponList[i];
        index = inv.weaponList.IndexOf(equippedWeapon);
    }
    void equipWeapon(string s) {
        
    }
}
