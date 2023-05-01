using UnityEngine;

[System.Serializable]
public delegate void DelegateUpgradeEffect(Upgrade upgrade);

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Incremental Clicker/Upgrade Data", order = 1)]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public string description;
    public Sprite icon;
    public int baseCost;
    public float costMultiplier;
    public float effectValue;
    public DelegateUpgradeEffect effect;
}
