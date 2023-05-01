using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public ClickerController clickerController;
    public List<UpgradeData> upgradeDataList;
    private List<Upgrade> upgrades;

    void Start()
    {
        clickerController = ClickerController.Instance;

        upgrades = new List<Upgrade>();

        foreach (UpgradeData upgradeData in upgradeDataList)
        {
            upgrades.Add(new Upgrade(upgradeData));
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
