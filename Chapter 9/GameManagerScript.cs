using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public Vector3[] waypoints;

    private LivesCounterScript livesCounter;

    private bool isAreaAllowed;
    public bool GetIsAreaAllowed() {
        return isAreaAllowed;
    }

    
    public GameObject enemyPrefab;
    public Vector3 SpawnPoint;

    public int numberOfEnemiesToSpawn = 50;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;


	// Use this for initialization
	void Start () {
        livesCounter = GameObject.Find("LivesCounter").GetComponent<LivesCounterScript>();

        StartCoroutine("SpawnEnemies", numberOfEnemiesToSpawn);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnEnemies(int number) {
        for (int i = 0; i < number; i++) {
            Instantiate(enemyPrefab, SpawnPoint, Quaternion.identity);
            float ratio = i*1f / (number-1);
            float timeTowait = Mathf.Lerp(minSpawnTime, maxSpawnTime, 1 - ratio);
            //Debug.Log(timeTowait);
            yield return new WaitForSeconds(timeTowait);
        }

        //GameOverConditions
        bool isGameOver = false;
        while (!isGameOver) {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
                isGameOver = true;
                //GameOver Screen (win)
            }
            else {
                yield return new WaitForSeconds(1);
            }
        }
    }
    
    public void enemyHasReachedTheFortress() {
        livesCounter.loseLife(10);

        //GAMEOVER CONDITIONS
        if (livesCounter.getLives() <= 0) {
            StopCoroutine("SpawnEnemies");
            //GameOver Screen (loose)
        }
    }

    void OnMouseEnter() {
        isAreaAllowed = true;
    }

    void OnMouseExit() {
        isAreaAllowed = false;
    }

}
