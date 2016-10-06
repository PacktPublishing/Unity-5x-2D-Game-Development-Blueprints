using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    // The Player's speed
    public float speed = 10.0f;

    //Game boundaries
    private float leftWall = -4f;
    private float rightWall = 4f;
	
	// Update is called once per frame
	void Update () {
        // Get the horizontal axis that by default is bound to the arrow keys
        // The value is in the range -1 to 1
        // Make it move per seconds instead of frames
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // Move along the object's x-axis within the floor bounds
        if (transform.position.x + translation < rightWall &&
           transform.position.x + translation > leftWall)
            transform.Translate(translation, 0, 0);
    }
}
