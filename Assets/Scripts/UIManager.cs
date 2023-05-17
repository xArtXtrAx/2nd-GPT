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

    private void Awake()
    {
        _stringBuilder = new StringBuilder();

        GameManager.OnUpdateClicks += UpdateTotalClicksText;
        GameManager.OnUpdateClicks += UpdateClicksPerClickText;
        GameManager.OnUpdateClicks += UpdateClicksPerSecondText;
    }

    public void Start()
    {
        StartCoroutine(UpdateClicksPerSecond());

    }

    private void OnDestroy()
    {
        GameManager.OnUpdateClicks -= UpdateTotalClicksText;
        GameManager.OnUpdateClicks -= UpdateClicksPerClickText;
        GameManager.OnUpdateClicks -= UpdateClicksPerSecondText;
    }

    IEnumerator UpdateClicksPerSecond()
    {
        while (true)
        {
            _clicksPerSecondText.text = _stringBuilder.Clear().Append("Clicks Per Second: ").Append(Mathf.FloorToInt(GameManager.Instance._clicksPerSecond)).ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateTotalClicksText()
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("Total Clicks: ");
        _stringBuilder.Append(Mathf.FloorToInt(GameManager.Instance._totalClicks));
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
