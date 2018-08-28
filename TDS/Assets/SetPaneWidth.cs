using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPaneWidth : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2((150 * transform.childCount) - 50, 100);
    }
	
}
