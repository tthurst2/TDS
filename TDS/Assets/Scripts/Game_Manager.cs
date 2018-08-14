using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {
    private bool gameHasEnded = false;
    private int score = 0;

    public void AddScore(int i) {
        score += i;
    }

    public void EndGame() {
        if(!gameHasEnded) {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Restart();
        }
        
    }

    public void Restart() {
        SceneManager.LoadScene("_SCENE_");
    }
}
