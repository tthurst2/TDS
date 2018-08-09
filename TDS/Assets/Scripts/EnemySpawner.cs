using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    float spawnDistance = 10f;

    float enemyRate = 4;
    float nextEnemy = 1;
    float numEnemies = 0;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        nextEnemy -= Time.deltaTime;


        if (nextEnemy <= 0) {
            nextEnemy = enemyRate;
            enemyRate *= (float) .9;
            if(enemyRate < .25f) {
                enemyRate = .25f;
            }

           Vector3 offset =  Random.onUnitSphere;

            offset.z = 0;
            offset = offset.normalized * spawnDistance;


            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
            numEnemies++;
        }
	}

    //DATED AND LEGACY
    private void OnGUI() {

            GUI.Label(new Rect(Screen.width - 75, 0, 100, 50), "Score: " + numEnemies);
    }

}
