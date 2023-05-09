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
