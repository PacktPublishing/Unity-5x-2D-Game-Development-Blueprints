using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesCounterScript : MonoBehaviour {

    private Text uiText;

    public int maxLives;
    private int lives;

	// Use this for initialization
	void Start () {
        lives = maxLives;
        uiText = this.GetComponent<Text>();
        updateLivesCounter();
	}

    //Return true if the player has no lives
    public bool loseLife(int damage){
        lives -= damage;
        if (lives > 0){
            updateLivesCounter();
            return false;
        }
        lives = 0;
        updateLivesCounter();
        return true;
    }

    private void updateLivesCounter(){
        uiText.text = lives.ToString();
    }
	
}
