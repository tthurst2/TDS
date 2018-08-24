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
    public List<IGunInterface> weapons = new List<IGunInterface>();
    public List<GameObject> bullets = new List<GameObject>();
    
    public void Add (IGunInterface weapon) {
        weapons.Add(weapon);
    }

    public void Remove(IGunInterface weapon) {
        weapons.Remove(weapon);
    }

}
