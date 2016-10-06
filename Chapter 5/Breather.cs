using UnityEngine;
using System.Collections;

public class Breather : MonoBehaviour {

    // The two positions the object will move between
    public Vector2 position1;
    public Vector2 position2;
    // The time waited between each position change
    public float waitTime;

    // Use this for initialization
    void Start() {
        StartCoroutine(Mover());
    }

    // Move and wait between positions
    IEnumerator Mover() {
        yield return new WaitForSeconds(Random.Range(0, 10) / 10);
        while (true) {
            transform.localPosition = position1;
            yield return new WaitForSeconds(waitTime);
            transform.localPosition = position2;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
