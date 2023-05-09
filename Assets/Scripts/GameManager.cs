using UnityEngine;
using TMPro;
using System.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI _totalClicksText;
    public TextMeshProUGUI _clicksPerClickText;
    public TextMeshProUGUI _clicksPerSecondText;

    private float _totalClicks;
    private float _clicksPerClick;
    private float _clicksPerSecond;

    private StringBuilder _stringBuilder;

    public delegate void UpdateClicksDelegate();
    public static event UpdateClicksDelegate OnUpdateClicks;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _clicksPerClick = 1;
        _stringBuilder = new StringBuilder();
    }

    private void Start()
    {
        UpdateTotalClicksText();
        UpdateClicksPerClickText();
        UpdateClicksPerSecondText();
    }

    public void AddClick()
    {
        _totalClicks += _clicksPerClick;
        UpdateTotalClicksText();
        OnUpdateClicks?.Invoke();
    }

    public bool CanAffordUpgrade(UpgradeSO upgrade)
    {
        float cost = upgrade.baseCost * Mathf.Pow(upgrade.costMultiplier, upgrade.level);
        return _totalClicks >= cost;
    }

    public void PurchaseUpgrade(UpgradeSO upgrade)
    {
        float cost = upgrade.baseCost * Mathf.Pow(upgrade.costMultiplier, upgrade.level);
        _totalClicks -= cost;
        _clicksPerClick += 1;
        upgrade.level += 1;
        UpdateTotalClicksText();
        UpdateClicksPerClickText();
        OnUpdateClicks?.Invoke();
    }

    public float GetUpgradeProgress(UpgradeSO upgrade)
    {
        float cost = upgrade.baseCost * Mathf.Pow(upgrade.costMultiplier, upgrade.level);
        return Mathf.Clamp(_totalClicks / cost, 0f, 1f);
    }

    public float GetMaxAllowedClicks(UpgradeSO upgrade)
    {
        float availableClicks = _totalClicks;
        float upgradeCost = upgrade.baseCost * Mathf.Pow(upgrade.costMultiplier, upgrade.level);
        int maxClicks = 0;

        while (availableClicks >= upgradeCost)
        {
            maxClicks++;
            availableClicks -= upgradeCost;
            upgradeCost *= upgrade.costMultiplier;
        }

        return maxClicks;
    }


    private void UpdateTotalClicksText()
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("Total Clicks: ");
        _stringBuilder.Append(Mathf.FloorToInt(_totalClicks));
        _totalClicksText.text = _stringBuilder.ToString();
    }

    private void UpdateClicksPerClickText()
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("Clicks Per Click: ");
        _stringBuilder.Append(Mathf.FloorToInt(_clicksPerClick));
        _clicksPerClickText.text = _stringBuilder.ToString();
    }

    private void UpdateClicksPerSecondText()
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("Clicks Per Second: ");
        _stringBuilder.Append(Mathf.FloorToInt(_clicksPerSecond));
        _clicksPerSecondText.text = _stringBuilder.ToString();
    }
}
