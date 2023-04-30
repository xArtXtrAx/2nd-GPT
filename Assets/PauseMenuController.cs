using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Button tab1Button;
    public Button tab2Button;
    public TextMeshProUGUI tab1Text;
    public TextMeshProUGUI tab2Text;
    public Image background;

    public Color panelColor1;
    public Color panelColor2;

    void Start()
    {
        tab1Button.onClick.AddListener(() => SwitchToTab1());
        tab2Button.onClick.AddListener(() => SwitchToTab2());
    }

    void SwitchToTab1()
    {
        Color newColor1 = panelColor1;
        newColor1.a = background.color.a;
        background.color = newColor1;
        tab1Text.gameObject.SetActive(true);
        tab2Text.gameObject.SetActive(false);
    }

    void SwitchToTab2()
    {
        Color newColor2 = panelColor2;
        newColor2.a = background.color.a;
        background.color = newColor2;
        tab1Text.gameObject.SetActive(false);
        tab2Text.gameObject.SetActive(true);
    }
}
