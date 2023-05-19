using UnityEngine;
using TMPro;
using System.Text;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float _totalClicks;
    public float _clicksPerClick;
    public float _clicksPerSecond;

    public float _clicksToAdd;

    public delegate void UpdateClicksDelegate();
    public static event UpdateClicksDelegate OnUpdateClicks;

    public delegate void ButtonClickDelegate();
    public static event ButtonClickDelegate OnButtonClick;


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
    }


    private void Update()
    {
        _totalClicks += _clicksPerSecond * Time.deltaTime;

        OnUpdateClicks?.Invoke();
    }


    public void AddClick()
    {
        _totalClicks += _clicksPerClick;
        OnButtonClick?.Invoke();
        OnUpdateClicks?.Invoke();
    }

    public void IncreaseClicksPerSecond(float amount)
    {
        _clicksPerSecond += amount;
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
        switch (upgrade.upgradeType)
        {
            case UpgradeSO.UpgradeType.ClicksPerClick:
                {
                    _clicksPerClick += upgrade.power;
                    break;
                }
            case UpgradeSO.UpgradeType.ClicksPerSecond:
                {
                    _clicksPerSecond += upgrade.power;
                    break;
                }
        }
        upgrade.level += 1;
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
}
