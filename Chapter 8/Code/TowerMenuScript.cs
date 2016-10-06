using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TowerMenuScript : MonoBehaviour {

    MoneyCounterScript moneyCounter;

    [HideInInspector]
    public TowerScript currentTower;

    private Image uiImage;
    public Text upgradePriceText;
    public Text sellPriceText;

    [Header("Level 0 Settings")]
    public Sprite menuLevel0;
    public int upgradePriceLevel0;
    public int sellPriceLevel0;

    [Header("Level 1 Settings")]
    public Sprite menuLevel1;
    public int upgradePriceLevel1;
    public int sellPriceLevel1;

    [Header("Level 2 Settings")]
    public Sprite menuLevel2;
    public int sellPriceLevel2;
    

    private int level;
    private int currentUpgradePrice;
    private int currentSellPrice;

	// Use this for initialization
	void Awake () {
        moneyCounter = GameObject.Find("MoneyCounter").GetComponent<MoneyCounterScript>();
        uiImage = GetComponent<Image>();
	}

    void OnEnable() {
        level = currentTower.upgradeLevel;
        switch (level) {
            case 0:
                uiImage.sprite = menuLevel0;
                upgradePriceText.text = "$" + upgradePriceLevel0.ToString();
                currentUpgradePrice = upgradePriceLevel0;
                sellPriceText.text = "$" + sellPriceLevel0.ToString();
                currentSellPrice = sellPriceLevel0;
                break;
            case 1:
                uiImage.sprite = menuLevel1;
                upgradePriceText.text = "$" + upgradePriceLevel1.ToString();
                currentUpgradePrice = upgradePriceLevel1;
                sellPriceText.text = "$" + sellPriceLevel1.ToString();
                currentSellPrice = sellPriceLevel1;
                break;
            case 2:
                uiImage.sprite = menuLevel2;
                upgradePriceText.text = "-";
                sellPriceText.text = "$" + sellPriceLevel2.ToString();
                currentSellPrice = sellPriceLevel2;
                break;
        }
    }

    public void upgrade() {
        if (level == 2)
            return;
        int money = moneyCounter.getMoney();
        if (money >= currentUpgradePrice) {
            moneyCounter.changeMoney(-currentUpgradePrice);
            currentTower.Upgrade();
        }
    }

    public void sell() {
            moneyCounter.changeMoney(currentSellPrice);
            Destroy(currentTower.gameObject);
    }
}
