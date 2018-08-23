 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    public List<GameObject> weapons = new List<GameObject>();

    public void Add (GameObject weapon) {
        weapons.Add(weapon);
    }

    public void Remove(GameObject weapon) {
        weapons.Remove(weapon);
    }

}
