using UnityEngine;
using System.Collections;

public class PlacingTowerScript : MonoBehaviour {

    private GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 7));
        if (Input.GetMouseButtonDown(0) && gameManager.GetIsAreaAllowed()) {
            GetComponent<TowerScript>().enabled = true;
            gameObject.AddComponent<BoxCollider2D>();
            Destroy(this);
        }
	}
}
