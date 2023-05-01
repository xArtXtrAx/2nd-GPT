using System.Collections;
using TMPro;
using UnityEngine;

public class ClickerController : MonoBehaviour
{
    public TextMeshProUGUI clickCountText;
    public int clickCount;
    public int clickValue = 1;
    public int autoClickValue = 1;
    public float autoClickRate = 0f;

    public static ClickerController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Another instance of ClickerController already exists!");
        }
    }

    private void Start()
    {
        StartCoroutine(AutoClick());
    }

    public void IncrementClickCount()
    {
        clickCount += clickValue;
        clickCountText.text = "Clicks: " + clickCount;
    }

    public void IncreaseClickValue(Upgrade upgrade)
    {
        clickValue += Mathf.RoundToInt(upgrade.upgradeData.effectValue);
    }

    public void IncreaseAutoClickRate(Upgrade upgrade)
    {
        autoClickRate += upgrade.upgradeData.effectValue;
    }

    public void DecreaseClickCount(int amount)
    {
        clickCount -= amount;
        clickCountText.text = "Clicks: " + clickCount;
    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            if (autoClickRate > 0f)
            {
                yield return new WaitForSeconds(1f / autoClickRate);
                clickCount += autoClickValue;
                clickCountText.text = "Clicks: " + clickCount;
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
