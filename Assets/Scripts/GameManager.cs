using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI upgradeButtonText;
    public ExponentialUpgrade clickUpgrade;

    private float counter;
    private int clicksPerClick;
    private int upgradeLevel;

    private void Start()
    {
        counter = 0;
        clicksPerClick = 1;
        upgradeLevel = 0;
        UpdateCounterText();
        UpdateUpgradeButtonText();
    }

    public void OnMainButtonClick()
    {
        counter += clicksPerClick;
        UpdateCounterText();
    }

    public void OnUpgradeButtonClick()
    {
        float upgradeCost = GetUpgradeCost();

        if (counter >= upgradeCost)
        {
            counter -= upgradeCost;
            clicksPerClick += clickUpgrade.effect;
            upgradeLevel++;

            UpdateCounterText();
            UpdateUpgradeButtonText();
        }
    }

    private void UpdateCounterText()
    {
        counterText.text = $"Counter: {counter:F0}";
    }

    private void UpdateUpgradeButtonText()
    {
        float upgradeCost = GetUpgradeCost();
        upgradeButtonText.text = $"Upgrade ({upgradeCost:F0})";
    }

    private float GetUpgradeCost()
    {
        return clickUpgrade.baseCost * Mathf.Pow(clickUpgrade.exponentialFactor, upgradeLevel);
    }
}
