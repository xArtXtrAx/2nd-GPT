using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrades/Upgrade Clicks Per Click")]
public class UpgradeSO : ScriptableObject
{
    public string upgradeName;
    public float baseCost;
    public float costMultiplier;
    public float level;
    public float clicksRequired;
    public float maxAllowedClicks;
}
