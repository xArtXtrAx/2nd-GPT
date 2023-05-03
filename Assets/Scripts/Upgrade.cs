using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public double baseCost;
    public double costMultiplier;
    public UpgradeType upgradeType;
    public double effectValue;
    public double costIncreaseFactor;

    public enum UpgradeType
    {
        ClicksPerClick,
        ClicksPerSecond,
        // Add other upgrade types here as needed.
    }
}
