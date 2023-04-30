using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Button[] tabs;
    public Color activeTabColor;
    public Color inactiveTabColor;

    private int activeTabIndex;

    private void Start()
    {
        // Set the first tab as active by default
        activeTabIndex = 0;
        UpdateTabColors();
    }

    public void SetActiveTab(int tabIndex)
    {
        activeTabIndex = tabIndex;
        UpdateTabColors();
    }

    private void UpdateTabColors()
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            ColorBlock colorBlock = tabs[i].colors;
            colorBlock.normalColor = (i == activeTabIndex) ? activeTabColor : inactiveTabColor;
            tabs[i].colors = colorBlock;
        }
    }
}
