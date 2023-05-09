using UnityEngine;
using UnityEngine.UI;

public class ClickerButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(HandleClick);
    }

    private void HandleClick()
    {
        GameManager.Instance.AddClick();
    }
}
