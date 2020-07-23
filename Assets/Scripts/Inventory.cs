 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    #region Singleton
    public static Inventory instance;

    void Awake () {

        if (instance != null) {
            Debug.LogWarning("More than one inventory found");
            return;
        }

        instance = this;
    }
    #endregion
    //Weapon list
    public List<GameObject> weaponList = new List<GameObject>();
    public List<GameObject> subWeaponList = new List<GameObject>();
    public List<GameObject> bullets = new List<GameObject>();

    void Start() {
    }

    public void Add (Weapon weapon) {
    }

    public void Remove(Weapon weapon) {
    }

}
