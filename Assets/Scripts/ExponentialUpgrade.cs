using UnityEngine;

[CreateAssetMenu(fileName = "NewExponentialUpgrade", menuName = "Upgrade System/Exponential Upgrade")]
public class ExponentialUpgrade : ScriptableObject
{
    public string upgradeName;
    public Sprite icon;
    public float baseCost;
    public float exponentialFactor;
    public int effect;
}
