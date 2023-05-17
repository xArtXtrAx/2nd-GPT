using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Upgrades/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    public string upgradeName;
    public float baseCost;
    public float costMultiplier;
    public float level;
    public float clicksRequired;
    public float maxAllowedClicks;
    [SerializeField] private UpgradeType _upgradeType;
    [SerializeField] private Tier _tier;
    [SerializeField] private float _power;


    public enum Tier
    {
        Tier1,
        Tier2,
        Tier3,
        Tier4,
        Tier5
        // Add more tiers here as needed
    }

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

    public Tier tier
    {
        get { return _tier; }
    }

    public float power
    {
        get { return _power; }
    }

}
