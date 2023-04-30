using UnityEngine;
using UnityEngine.UI;

public class MenuColorController : MonoBehaviour
{
    public Color[] panelColors;
    private Image panelImage;

    private void Start()
    {
        panelImage = GetComponent<Image>();
        if (panelColors.Length > 0)
        {
            panelImage.color = panelColors[0]; // Set the first color by default
        }
    }

    public void ChangePanelColor(int colorIndex)
    {
        if (colorIndex >= 0 && colorIndex < panelColors.Length)
        {
            panelImage.color = panelColors[colorIndex];
        }
    }
}
