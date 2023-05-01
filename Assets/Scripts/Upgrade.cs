[System.Serializable]
public class Upgrade
{
    public UpgradeData upgradeData;
    public int level;
    public int currentCost;

    public Upgrade(UpgradeData upgradeData)
    {
        this.upgradeData = upgradeData;
        level = 0;
        currentCost = upgradeData.baseCost;
    }
}
