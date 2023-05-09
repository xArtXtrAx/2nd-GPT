using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ClickerManager : MonoBehaviour
{
    public Button ClickerButton;
    public TextMeshProUGUI TotalClicksText;
    public TextMeshProUGUI ClicksPerClickText;
    public TextMeshProUGUI ClicksPerSecondText;

    private int _totalClicks;
    private int _clicksPerClick;
    private float _clicksPerSecond;

    private StringBuilder _stringBuilder;

    private void Start()
    {
        _totalClicks = 0;
        _clicksPerClick = 1;
        _clicksPerSecond = 0;

        _stringBuilder = new StringBuilder();

        UpdateUI();

        ClickerButton.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        _totalClicks += _clicksPerClick;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _stringBuilder.Clear();

        _stringBuilder.Append("Total Clicks: ");
        _stringBuilder.Append(_totalClicks);
        TotalClicksText.text = _stringBuilder.ToString();

        _stringBuilder.Clear();

        _stringBuilder.Append("Clicks per Click: ");
        _stringBuilder.Append(_clicksPerClick);
        ClicksPerClickText.text = _stringBuilder.ToString();

        _stringBuilder.Clear();

        _stringBuilder.Append("Clicks per Second: ");
        _stringBuilder.Append(_clicksPerSecond);
        ClicksPerSecondText.text = _stringBuilder.ToString();
    }
}
