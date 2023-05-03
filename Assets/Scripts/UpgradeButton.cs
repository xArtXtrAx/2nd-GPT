using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public ClickerGameManager gameManager;
    public Upgrade upgrade;
    public Button button;
    public Slider progressSlider;

    public TextMeshProUGUI costText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI availableUpgradesText;

    private double currentCost;
    private int upgradeLevel;
    private int availableUpgrades;

    void Awake()
    {
        currentCost = upgrade.baseCost;
        UpdateCostText();
        UpdateLevelText();
        UpdateAvailableUpgradesText();
    }

    void OnValidate()
    {
        if (button == null)
        {
            button = GetComponent<Button>();
        }

        if (costText == null)
        {
            costText = GetComponentInChildren<TextMeshProUGUI>();
        }

        if (progressSlider == null)
        {
            progressSlider = GetComponentInChildren<Slider>();
        }

        if (levelText == null)
        {
            levelText = GetComponentInChildren<TextMeshProUGUI>();
        }

        if (availableUpgradesText == null)
        {
            availableUpgradesText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    void Start()
    {
        button.onClick.AddListener(ApplyUpgrade);
    }

    void Update()
    {
        CalculateAvailableUpgrades();
        button.interactable = availableUpgrades > 0;
        UpdateAvailableUpgradesText();
        UpdateProgressSlider();
    }

    private void ApplyUpgrade()
    {
        if (availableUpgrades > 0)
        {
            gameManager.clicksPerClick += upgrade.effectValue;
            availableUpgrades--;
            upgradeLevel++;
            UpdateAvailableUpgradesText();
            UpdateLevelText();
        }
    }

    private void CalculateAvailableUpgrades()
    {
        availableUpgrades = 0;
        double cost = currentCost;
        double totalClicks = gameManager.totalClicks;

        while (totalClicks >= cost)
        {
            availableUpgrades++;
            totalClicks -= cost;
            cost *= upgrade.costIncreaseFactor;
        }
    }

    private void UpdateAvailableUpgradesText()
    {
        availableUpgradesText.text = $"{availableUpgrades}";
    }

    private void UpdateLevelText()
    {
        levelText.text = $"Level: {upgradeLevel}";
    }

    private void UpdateCostText()
    {
        costText.text = $"Cost: {currentCost}";
    }

    private void UpdateProgressSlider()
    {
        double cost = currentCost;
        double remainingClicks = gameManager.totalClicks;

        for (int i = 0; i < availableUpgrades; i++)
        {
            remainingClicks -= cost;
            cost *= upgrade.costIncreaseFactor;
        }

        progressSlider.value = (float)(1 - remainingClicks / cost);
    }
}
