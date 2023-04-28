using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerGameController : MonoBehaviour
{
    public TextMeshProUGUI clickCounterText;
    public TextMeshProUGUI clicksPerSecondCounterText;
    public TextMeshProUGUI clicksPerClickText;

    public Button mainButton;
    public Button upgradeButton;
    public RectTransform progressBarFill;

    private int clickCounter = 0;
    private int clicksPerSecond = 0;
    private int clicksPerClick = 1;
    private int upgradeClickThreshold = 10;

    private float nextUpgradeClickTime;

    public Button incrementButton;
    public Scrollbar incrementButtonProgress;

    public TextMeshProUGUI incrementButtonCounterText;
    public TextMeshProUGUI powerLevelText;

    private int incrementButtonThreshold = 10;
    private int incrementButtonClicks = 1;
    private float incrementButtonMultiplier = 1.4f;

    public Image incrementButtonHandle;


    void Start()
    {
        mainButton.onClick.AddListener(OnClickMainButton);
        upgradeButton.onClick.AddListener(OnClickUpgradeButton);
        
        incrementButton.onClick.AddListener(OnClickIncrementButton);
        incrementButtonProgress.size = 0f;


        UpdateUI();
    }

    void Update()
    {
        // Calculate the available clicks and update the text
        int availableClicks = Mathf.FloorToInt((float)clickCounter / incrementButtonThreshold);
        incrementButtonCounterText.text = $"Available Clicks: {availableClicks}";

        // Update the incrementButton clickability and progress
        if (clickCounter >= incrementButtonThreshold)
        {
            incrementButton.interactable = true;
            incrementButtonProgress.size = (float)(clickCounter % incrementButtonThreshold) / incrementButtonThreshold;
        }
        else
        {
            incrementButton.interactable = false;
            incrementButtonProgress.size = (float)(clickCounter % incrementButtonThreshold) / incrementButtonThreshold;
        }

        // Adjust the scrollbar handle's alpha value
        Color handleColor = incrementButtonHandle.color;
        handleColor.a = clickCounter > 0 ? 1f : 0f;
        incrementButtonHandle.color = handleColor;

        powerLevelText.text = $"Power Level: {clicksPerClick - 1}";

        // Update the total click counter text
        clickCounterText.text = $"Total Clicks: {clickCounter}";
        clicksPerSecondCounterText.text = $"Clicks Per Second: {clicksPerSecond}";
        clicksPerClickText.text = $"Clicks Per Click: {clicksPerClick}";
    }



    void OnClickIncrementButton()
    {
        if (clickCounter >= incrementButtonThreshold)
        {
            clicksPerClick++;
            incrementButtonThreshold = Mathf.CeilToInt(incrementButtonThreshold * incrementButtonMultiplier);
            UpdateUI();
        }
    }


    void OnClickMainButton()
    {
        clickCounter += clicksPerClick;
        UpdateUI();
    }

    void OnClickUpgradeButton()
    {
        if (clickCounter >= upgradeClickThreshold)
        {
            clicksPerClick++;
            clickCounter = 0;
            upgradeClickThreshold *= 10;
            nextUpgradeClickTime = Time.time + 1f;

            UpdateUI();
        }
    }

    void UpdateUI()
    {
        clickCounterText.text = $"Total Clicks: {clickCounter}";
        clicksPerClickText.text = $"Clicks per Click: {clicksPerClick}";
    }
}
