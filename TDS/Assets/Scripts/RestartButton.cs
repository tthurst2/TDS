using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
      // gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Time.timeScale);
	}

    public void ShowRestartButton() {
        gameObject.SetActive(true);
    }

    public void ButtonClick() {
        SceneManager.LoadScene(0);
    }

}
