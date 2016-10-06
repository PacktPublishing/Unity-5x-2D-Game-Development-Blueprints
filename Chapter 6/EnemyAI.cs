using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

	// The target to follow or chase
	public Transform target;
	
	// Character's movement speed
	public float speed = 85;
	// How often the path is updated every second
	public float updateRate = 2;
	// Required distance to be reached before continuing the path
	public float nextWaypointDistance = 0.3f;
	// Required distance to the target before stopping
	public float endDistance = 0.8f;
	
	
	// Flag to check if the path has ended
	public bool pathEnded = false;
	// The calculated path
	public Path path;
	// Character's RigidBody component
	Rigidbody2D charRigidBody2D;
	// Character's Seeker component
	Seeker seeker;
	// Current waypoint
	int curWaypointIndex=0;
	
	// Use this for initialization
	void Start () {
		// Assign the required components
		seeker=GetComponent<Seeker>();
		charRigidBody2D=GetComponent<Rigidbody2D>();
		// Start the path
		StartCoroutine(UpdatePath());
	}
	
	// Update is called once per frame
	void Update () {
		if(path==null) return;
		// On reaching the end of the path
		if(curWaypointIndex==path.vectorPath.Count)
		{
			if(pathEnded) return;
			charRigidBody2D.velocity=Vector3.zero;
			pathEnded=true;
		}
		else
		{
			// If we approached the end distance
			if(Vector3.Distance(transform.position,target.position)<endDistance)
			{
				// Finish the path
				curWaypointIndex=path.vectorPath.Count;
			}
			else
			{
				// Move towards the current waypoint
				pathEnded=false;
				float dist=Vector3.Distance(transform.position,path.vectorPath[curWaypointIndex]);
				Vector3 dir=(path.vectorPath[curWaypointIndex]-transform.position).normalized;
				charRigidBody2D.velocity=dir*speed*Time.fixedDeltaTime;
				if(dist<nextWaypointDistance) curWaypointIndex++;
			}
		}
	}

	// Update the path then wait before updating again
	IEnumerator UpdatePath () {
		if(Vector3.Distance(transform.position,target.position)>endDistance)
		{
			seeker.StartPath(transform.position,target.position,OnPathComplete);
		}
		yield return new WaitForSeconds(1/updateRate);
		StartCoroutine(UpdatePath());
	}

	// Called on successfully calculating the path
	void OnPathComplete (Path p) {
		if(p.error)
		{
			// Report error
			print (p.error);
		}
		else
		{
			// Assign to the new calculated path
			path=p;
			curWaypointIndex=0;
		}
	}
}
