using UnityEngine;

public delegate void UpgradeEffect(Upgrade upgrade);

[CreateAssetMenu(fileName = "UpgradeData", menuName = "ScriptableObjects/UpgradeData", order = 1)]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public int baseCost;
    public float costMultiplier;
    public UpgradeEffect effect;
}
