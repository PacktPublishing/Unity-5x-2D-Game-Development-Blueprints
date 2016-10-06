using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyCounterScript : MonoBehaviour {
    
    private Text uiText;

    private int money = 0;

	// Use this for initialization
	void Start () {
        uiText = this.GetComponent<Text>();
        updateMoneyCounter();
	}

    public void changeMoney(int ammount){
        money += ammount;
        if (money < 0){
            money = 0;
        }
        updateMoneyCounter();
    }

    public int getMoney() {
        return money;
    }

    private void updateMoneyCounter(){
        uiText.text = "$" + money.ToString();
    }

}
