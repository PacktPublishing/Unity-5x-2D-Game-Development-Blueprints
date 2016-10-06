using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float speed = 1f;
	public Vector3 direction;


	// Use this for initialization
	void Start () {
		direction = direction.normalized;
		float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * Time.deltaTime * speed;
	}
}
