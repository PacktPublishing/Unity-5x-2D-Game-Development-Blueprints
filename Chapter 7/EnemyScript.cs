using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	public float speed = 1f;
	private Vector3[] waypoints;
	private int counter = 0;
	private const float changeDist = 0.001f;
	
	void Start () {
		
	}

	void Update () {
		if(counter==waypoints.Length){
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
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
