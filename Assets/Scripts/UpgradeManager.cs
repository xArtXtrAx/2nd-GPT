using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public ClickerController clickerController;
    public List<UpgradeData> upgradeDataList;
    public List<Button> upgradeButtons;
    private List<Upgrade> upgrades;

    void Start()
    {
        clickerController = ClickerController.Instance;

        upgrades = new List<Upgrade>();

        foreach (UpgradeData upgradeData in upgradeDataList)
        {
            upgrades.Add(new Upgrade(upgradeData));
        }

        // Assign the effect methods for each UpgradeData
        upgradeDataList[0].effect = clickerController.IncreaseClicksPerClick;
        upgradeDataList[1].effect = clickerController.IncreaseExtraClicksPerSecond;
        upgradeDataList[2].effect = clickerController.DoubleTotalClicks;

        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            int index = i;
            upgradeButtons[i].onClick.AddListener(() => PurchaseUpgrade(index));
        }
    }

    public void PurchaseUpgrade(int index)
    {
        Upgrade upgrade = upgrades[index];

        if (clickerController.clickCount >= upgrade.currentCost)
        {
            clickerController.DecreaseClickCount(upgrade.currentCost);
            upgrade.level++;
            upgrade.currentCost = Mathf.RoundToInt(upgrade.upgradeData.baseCost * Mathf.Pow(upgrade.upgradeData.costMultiplier, upgrade.level));
            upgrade.upgradeData.effect(upgrade);
        }
    }
}
