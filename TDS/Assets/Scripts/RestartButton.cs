using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // gameObject.SetActive(false);
        GameObject.Find("RestartButton").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("RestartButton").GetComponent<CanvasGroup>().interactable = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ShowRestartButton() {
        gameObject.SetActive(true);
    }

    public void ButtonClick() {
        SceneManager.LoadScene(0);
        gameObject.GetComponent<Button>().interactable = false;
    }

}
