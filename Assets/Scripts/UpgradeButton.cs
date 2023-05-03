using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public Upgrade upgrade;
    public ClickerGameManager gameManager;
    public TextMeshProUGUI costText;

    private Button button;
    private double currentCost;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ApplyUpgrade);
        currentCost = upgrade.baseCost;
        UpdateCostText();
    }

    void Update()
    {
        button.interactable = gameManager.totalClicks >= currentCost;
    }

    private void ApplyUpgrade()
    {
        if (gameManager.totalClicks >= currentCost)
        {
            gameManager.totalClicks -= currentCost;
            currentCost *= upgrade.costMultiplier;

            switch (upgrade.upgradeType)
            {
                case Upgrade.UpgradeType.ClicksPerClick:
                    gameManager.clicksPerClick += upgrade.effectValue;
                    break;
                case Upgrade.UpgradeType.ClicksPerSecond:
                    gameManager.clicksPerSecond += upgrade.effectValue;
                    break;
                    // Handle other upgrade types here as needed.
            }

            UpdateCostText();
        }
    }

    private void UpdateCostText()
    {
        costText.text = $"{Mathf.RoundToInt((float)currentCost)}";
    }
}
