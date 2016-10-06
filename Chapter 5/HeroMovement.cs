using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

    // Player's movement speed
    public float speed = 4.0f;
    // Player's RigidBody component
    Rigidbody2D playerRigidBody2D;

    // Use this for initialization
    void Start() {
        // Get the RigidBody component
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float movePlayerX = Input.GetAxis("Horizontal");
        float movePlayerY = Input.GetAxis("Vertical");
        playerRigidBody2D.velocity = new Vector2(movePlayerX * speed, movePlayerY * speed);
    }
}
