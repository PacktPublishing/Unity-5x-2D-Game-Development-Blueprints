using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyTowerScript : MonoBehaviour {

    MoneyCounterScript moneyCounter;
    
    public Text uiPrice;
    public int price;
    public GameObject towerPrefab;

	// Use this for initialization
	void Start () {
        moneyCounter = GameObject.Find("MoneyCounter").GetComponent<MoneyCounterScript>();
        uiPrice.text = "$" + price;
	}

    public void OnClick() {
        int money = moneyCounter.getMoney();
        if (money >= price) {
            moneyCounter.changeMoney(-price);
            Instantiate(towerPrefab);
        }
    }
}
