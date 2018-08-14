using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {

    float respawnTimer = 1f;

    public GameObject playerPrefab;
    GameObject playerInstance;
    public int numLives = 4;
    public Text livesText;
    // Use this for initialization
    void Start () {
        SpawnPlayer();
	}
	
    void SpawnPlayer() {
        numLives--;
        //for lives GUI
        GameObject.Find("LivesPanel").GetComponent<Text>().text = "Lives: " + numLives;
        respawnTimer = 1;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {
		if(playerInstance == null && numLives > 0) {
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0) {
                SpawnPlayer();
            }
        }
	}

    //DATED AND LEGACY
    private void OnGUI() {
        if(numLives > 0 || playerInstance!=null) {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives: " + numLives);
        }
        else {
            GUI.Label(new Rect(Screen.width/2-50, Screen.height/2 -25, 100, 50), "Game Over!");
            Time.timeScale = 0.0f;
            
            FindObjectOfType<Game_Manager>().EndGame();
        }
        
    }

}
