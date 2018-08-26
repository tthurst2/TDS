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
    public List<Weapon> weapons = new List<Weapon>();
    public List<GameObject> bullets = new List<GameObject>();

    void Start() {
    }

    public void Add (Weapon weapon) {
        weapons.Add(weapon);
    }

    public void Remove(Weapon weapon) {
        weapons.Remove(weapon);
    }

}
