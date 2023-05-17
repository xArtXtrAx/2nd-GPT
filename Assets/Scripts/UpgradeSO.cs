using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrades/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public string upgradeName;
    public float baseCost;
    public float costMultiplier;
    public float level;
    public float effect;
    public float clicksRequired;
    public float maxAllowedClicks;
    [SerializeField] private UpgradeType _upgradeType;


    public enum UpgradeType
    {
        ClicksPerClick,
        ClicksPerSecond
        // Add more types here as needed
    }

    public void ResetLevel()
    {
        level = 0;
    }

    public UpgradeType upgradeType
    {
        get { return _upgradeType; }
    }
}
