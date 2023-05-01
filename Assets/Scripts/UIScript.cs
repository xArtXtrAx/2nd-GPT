using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public ClickerController clickerController;
    public TextMeshProUGUI totalClicksText;
    public TextMeshProUGUI clicksPerClickText;
    public TextMeshProUGUI extraClicksPerSecondText;

    void Update()
    {
        totalClicksText.text = "Total Clicks: " + clickerController.clickCount;
        clicksPerClickText.text = "Clicks Per Click: " + clickerController.clicksPerClick;
        extraClicksPerSecondText.text = "Clicks Per Second: " + clickerController.extraClicksPerSecond;
    }
}
