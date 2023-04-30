using TMPro;
using UnityEngine;

public class PolygonClickController : MonoBehaviour
{
    public Camera mainCamera;
    public TextMeshProUGUI popupText;
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (polygonCollider.OverlapPoint(mousePosition))
            {
                ShowPopupText(mainCamera.WorldToScreenPoint(mousePosition));
            }
        }
    }

    public void ShowPopupText(Vector3 position)
    {
        popupText.transform.position = position;
        popupText.gameObject.SetActive(true);
        Invoke("HidePopupText", 2.0f);
    }

    private void HidePopupText()
    {
        popupText.gameObject.SetActive(false);
    }
}
