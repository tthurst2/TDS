using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    Inventory inv = Inventory.instance;
    public SelectedWeaponUI swUI;

    public void LoadWeapons() {
        for(int i = 0; i < inv.weaponList.Count; i++) {
            GameObject go = Instantiate(inv.weaponList[i]);
            go.transform.parent = transform;
            go.SetActive(false);
        }
    }


    public void EquipWeapon(int index) {
        //Debug.Log("Equip Weapon: " + transform.childCount);
        //Debug.Log("Manager index :" + index);

        for (int i = 0; i <= transform.childCount - 1; i++) {
            if(i == index) {
                transform.GetChild(i).gameObject.SetActive(true);
                //update UI
                swUI.UpdateSelectedUI(i);
            }
            else {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
}
