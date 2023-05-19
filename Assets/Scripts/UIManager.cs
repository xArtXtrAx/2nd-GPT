using System.Text;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI _totalClicksText;
    public TextMeshProUGUI _clicksPerClickText;
    public TextMeshProUGUI _clicksPerSecondText;

    private StringBuilder _stringBuilder;
    private float _displayedTotalClicks;
    private float _targetTotalClicks;

    private void Awake()
    {
        _stringBuilder = new StringBuilder();

        GameManager.OnUpdateClicks += HandleUpdateClicks;
        GameManager.OnButtonClick += HandleUpdateClicks;
    }


    private void Update()
    {
        _targetTotalClicks = GameManager.Instance._totalClicks;

        if (_displayedTotalClicks < _targetTotalClicks)
        {
            _displayedTotalClicks += GameManager.Instance._clicksPerSecond * Time.deltaTime;
            UpdateTotalClicksText();
        }

        UpdateClicksPerClickText();
        UpdateClicksPerSecondText();
    }


    private void OnDestroy()
    {
        GameManager.OnUpdateClicks -= HandleUpdateClicks;
        GameManager.OnButtonClick -= HandleButtonClick;
    }

    private void HandleUpdateClicks()
    {
        _displayedTotalClicks = GameManager.Instance._totalClicks;
        _targetTotalClicks = GameManager.Instance._totalClicks;
        UpdateTotalClicksText();
    }



    private void HandleButtonClick()
    {
        _displayedTotalClicks = GameManager.Instance._totalClicks;
        _targetTotalClicks = GameManager.Instance._totalClicks;
        UpdateTotalClicksText();
    }

    private void UpdateTotalClicksText()
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("Total Clicks: ");
        _stringBuilder.Append(Mathf.FloorToInt(_displayedTotalClicks));
        _totalClicksText.text = _stringBuilder.ToString();
    }

    private void UpdateClicksPerClickText()
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("Clicks Per Click: ");
        _stringBuilder.Append(Mathf.FloorToInt(GameManager.Instance._clicksPerClick));
        _clicksPerClickText.text = _stringBuilder.ToString();
    }

    private void UpdateClicksPerSecondText()
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("Clicks Per Second: ");
        _stringBuilder.Append(Mathf.FloorToInt(GameManager.Instance._clicksPerSecond));
        _clicksPerSecondText.text = _stringBuilder.ToString();
    }
}
