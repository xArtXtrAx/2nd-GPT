using UnityEngine;
using TMPro;
using System.Text;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI _totalClicksText;
    public TextMeshProUGUI _clicksPerClickText;
    public TextMeshProUGUI _clicksPerSecondText;

    private StringBuilder _stringBuilder;
    private float _displayedTotalClicks;

    private void Awake()
    {
        _stringBuilder = new StringBuilder();

        GameManager.OnUpdateClicks += UpdateTotalClicksText;
        GameManager.OnUpdateClicks += UpdateClicksPerClickText;
        GameManager.OnUpdateClicks += UpdateClicksPerSecondText;
        GameManager.OnButtonClick += HandleButtonClick;
    }

    public void Start()
    {
        _displayedTotalClicks = GameManager.Instance._totalClicks;
        StartCoroutine(UpdateTotalClicksSmoothly());
    }

    private void OnDestroy()
    {
        GameManager.OnUpdateClicks -= UpdateTotalClicksText;
        GameManager.OnUpdateClicks -= UpdateClicksPerClickText;
        GameManager.OnUpdateClicks -= UpdateClicksPerSecondText;
        GameManager.OnButtonClick -= HandleButtonClick;
    }

    private void HandleButtonClick()
    {
        _displayedTotalClicks = GameManager.Instance._totalClicks;
        UpdateTotalClicksText();
    }

    IEnumerator UpdateTotalClicksSmoothly()
    {
        while (true)
        {
            float startValue = _displayedTotalClicks;
            float endValue = GameManager.Instance._totalClicks + GameManager.Instance._clicksPerSecond;
            float duration = 1f;
            float timePassed = 0f;

            while (timePassed < duration)
            {
                timePassed += Time.deltaTime;
                _displayedTotalClicks = Mathf.Lerp(startValue, endValue, timePassed / duration);
                UpdateTotalClicksText();
                yield return null;
            }

            // At the end of each second, update the displayed total clicks to match the actual total clicks
            _displayedTotalClicks = GameManager.Instance._totalClicks;
            startValue = _displayedTotalClicks;
            endValue = GameManager.Instance._totalClicks + GameManager.Instance._clicksPerSecond;
        }
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
