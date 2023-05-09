using UnityEngine;

public class ScriptableObjectResetter : MonoBehaviour
{
    public UpgradeSO[] upgradesToReset;

    private void Awake()
    {
        ResetAllUpgrades();
    }

    public void ResetAllUpgrades()
    {
        foreach (UpgradeSO upgrade in upgradesToReset)
        {
            upgrade.ResetLevel();
        }
    }
}
