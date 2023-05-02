using UnityEngine;
using TMPro;
using System.Text;

public class ClickerGameManager : MonoBehaviour
{
    public TextMeshProUGUI totalClicksText;
    public double totalClicks;
    public double clicksPerClick = 1;
    public double clicksPerSecond = 0;

    private StringBuilder stringBuilder;

    void Start()
    {
        totalClicks = 0;
        stringBuilder = new StringBuilder();
    }

    void Update()
    {
        UpdateTotalClicksText();
        AccumulateClicksPerSecond();
    }

    public void OnMainButtonClick()
    {
        totalClicks += clicksPerClick;
    }

    private void UpdateTotalClicksText()
    {
        stringBuilder.Clear();
        stringBuilder.Append(Mathf.RoundToInt((float)totalClicks));
        totalClicksText.text = stringBuilder.ToString();
    }

    private void AccumulateClicksPerSecond()
    {
        totalClicks += clicksPerSecond * Time.deltaTime;
    }
}
