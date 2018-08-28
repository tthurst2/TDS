using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedWeaponUI : MonoBehaviour {

    Color defaultColor = new Color(1f, 1f, 1f, 46f/255);

    public void UpdateSelectedUI(int index) {
        for (int i = 0; i < transform.childCount; i++) {
            if (i == index)
                transform.GetChild(i).GetComponent<Image>().color = new Color(39/255f, 60/255f, 255/255f, 255f/255);
            else
                transform.GetChild(i).GetComponent<Image>().color = defaultColor;
        }
    }

}
