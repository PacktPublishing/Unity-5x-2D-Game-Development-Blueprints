using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    // Enemy's speed
    public float speed = 1;
    // Current velocity used in Update
    Vector2 curVelocity;
    // Current scale used in Update
    Vector3 curScale;

    // Use this for initialization
    void Start() {
        //Set initial direction and speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed, 0);
    }

    // Update is called once per frame
    void Update() {
        //get the current velocity
        curVelocity = GetComponent<Rigidbody2D>().velocity;
        //Resume walking if the enemy stops
        if (curVelocity.x == 0) {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(curScale.x > 0 ? -1 : 1 * speed, 0);
        }
    }

    // Called when the object enters a trigger
    void OnTriggerEnter2D(Collider2D c) {
        if (c.tag == "Obstacle") {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * curVelocity.x, 0);
            curScale = transform.localScale;
            curScale.x *= -1;
            transform.localScale = curScale;
        }
        else if (c.name == "GroundCheck") {
            print("Killed By Jump!");
            Destroy(gameObject);
        }
    }

    // Called when the object enters a collision
    void OnCollisionEnter2D(Collision2D c) {
        if (c.collider.tag == "Obstacle") {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * curVelocity.x, 0);
            curScale = transform.localScale;
            curScale.x *= -1;
            transform.localScale = curScale;
        }
        else if (c.collider.tag == "Player") {
            c.transform.GetComponent<GameHandler>().SubtractHealth();
            Destroy(gameObject);
        }
    }
}

