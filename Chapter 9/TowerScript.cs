using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

    public int upgradeLevel;
    //CHAPTER 9
    public void Upgrade() {
        rangeRadius += 1f;
        reloadTime -= 0.5f;
        upgradeLevel++;
        towerMenu.SetActive(false);
    }
    //END

	public float rangeRadius;
	public float reloadTime;
	public GameObject bulletPrefab;
	
	private float elapsedTime;
	
	//CHAPTER 9
    public static GameObject towerMenu;
    //END
	
	// Update is called once per frame
	void Update () {
		if(elapsedTime >= reloadTime){
			elapsedTime = 0;
			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);
			if(hitColliders.Length != 0){
				float min = int.MaxValue;
				int index = -1;

				for(int i=0; i<hitColliders.Length; i++){
					if(hitColliders[i].tag == "Enemy"){
						float distance = Vector2.Distance(hitColliders[i].transform.position,transform.position);
						if (distance < min){
							index = i;
							min = distance;
						}
					}
				}
				if(index == -1)
					return;
				Transform target = hitColliders[index].transform;
				Vector2 direction = (target.position - transform.position).normalized;
				//Create Bullet
				GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
				bullet.GetComponent<BulletScript>().direction = direction;
			}
		}
		elapsedTime += Time.deltaTime;
	}

    //CHAPTER 9
    void OnMouseDown() {
        towerMenu.SetActive(false);
        towerMenu.GetComponent<TowerMenuScript>().currentTower = this;
        towerMenu.SetActive(true);
    }
    //END
}