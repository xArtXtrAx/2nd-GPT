using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class UpgradeButton : MonoBehaviour
{
    public UpgradeSO upgrade;
    public TextMeshProUGUI _levelText;
    public TextMeshProUGUI _costText;
    public TextMeshProUGUI _maxClicksText;
    public Slider _progressBar;

    private Button _button;
    private StringBuilder _stringBuilder;

    public delegate void UpgradeAction();
    public static event UpgradeAction OnUpgrade;

    private void OnEnable()
    {
        GameManager.OnUpdateClicks += UpdateButton;
    }

    private void OnDisable()
    {
        GameManager.OnUpdateClicks -= UpdateButton;
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(HandleUpgrade);
        _stringBuilder = new StringBuilder();

        UpdateButton();
    }

    private void UpdateButton()
    {
        _button.interactable = GameManager.Instance.CanAffordUpgrade(upgrade);

        _levelText.text = $"Level: {Mathf.FloorToInt(upgrade.level)}";
        _costText.text = $"Cost: {Mathf.FloorToInt(upgrade.baseCost * Mathf.Pow(upgrade.costMultiplier, upgrade.level))}";
        _maxClicksText.text = $"Max Clicks: {Mathf.FloorToInt(GameManager.Instance.GetMaxAllowedClicks(upgrade))}";

        float progress = GameManager.Instance.GetUpgradeProgress(upgrade);
        _progressBar.value = progress;
    }

    private void HandleUpgrade()
    {
        OnUpgrade?.Invoke();
        GameManager.Instance.PurchaseUpgrade(upgrade);
        UpdateButton();
    }
}
