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

    void Start()
    {
        mainButton.onClick.AddListener(OnClickMainButton);
        upgradeButton.onClick.AddListener(OnClickUpgradeButton);

        UpdateUI();
    }

    void Update()
    {
        if (clickCounter >= upgradeClickThreshold && Time.time >= nextUpgradeClickTime)
        {
            progressBarFill.anchorMax = new Vector2((float)clickCounter / upgradeClickThreshold, progressBarFill.anchorMax.y);
            progressBarFill.GetComponent<Image>().color = progressBarFill.anchorMax.x >= 1 ? Color.green : Color.blue;
            upgradeButton.interactable = true;
        }
        else
        {
            progressBarFill.anchorMax = new Vector2((float)clickCounter / upgradeClickThreshold, progressBarFill.anchorMax.y);
            progressBarFill.GetComponent<Image>().color = Color.blue;
            upgradeButton.interactable = false;
        }

        clicksPerSecondCounterText.text = $"Clicks per Second: {clicksPerSecond}";
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
