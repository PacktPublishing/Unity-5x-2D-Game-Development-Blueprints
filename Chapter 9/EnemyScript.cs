using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speed = 1f;

	private Vector3[] waypoints;
	private int counter = 0;

	private const float changeDist = 0.001f;

    //CHAPTER 9
    private GameManagerScript gameManager;
    private MoneyCounterScript moneyCounter;
    //END
	
	void Start () {
        //CHAPTER 9
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        moneyCounter = GameObject.Find("MoneyCounter").GetComponent<MoneyCounterScript>();
		//Grab Waypoints
        waypoints = gameManager.waypoints;
        //END
	}

	void Update () {
		if(counter==waypoints.Length){
            //CHAPTER 9
            gameManager.enemyHasReachedTheFortress();
            //END
			Destroy(gameObject);
			return;
		}else{
			float dist = Vector3.Distance(transform.position, waypoints[counter]);
			if(dist < changeDist){
				counter++;
			}else{	
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, waypoints[counter], step);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Bullet"){
            //CHAPTER 9
            moneyCounter.changeMoney(80);
            //END
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
