using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {

    // Player's health
    public float health = 2;
    // Player's score
    public float score = 0;
    // If the game is over
    public bool gameover = false;
    // The UI health variable
    public UnityEngine.UI.Text healthUI;
    // The UI score variable
    public UnityEngine.UI.Text ScoreUI;
    // The UI gameover object
    public GameObject gameOverUI;
    // The UI youwin object
    public GameObject youWinUI;

    // Called when the object enters in the trigger
    void OnTriggerEnter2D(Collider2D c) {
        if (c.name == "Coin") {
            AddScore();
            Destroy(c.gameObject);
        }
        else if (c.tag == "Water") {
            health = 0;
            healthUI.text = health.ToString();
            gameOverUI.SetActive(true);
            StopGame();
        }
        else if (c.tag == "Ending") {
            youWinUI.SetActive(true);
            StopGame();
        }
    }

    // Subtract from health
    public void SubtractHealth() {
        health -= 1;
        healthUI.text = health.ToString();
        if (health == 0) {
            gameOverUI.SetActive(true);
            StopGame();
        }
    }

    // Add score to player
    public void AddScore() {
        score += 10;
        ScoreUI.text = score.ToString();
    }

    // End the game
    public void StopGame() {
        gameover = true;
        gameObject.SetActive(false);
    }

}
