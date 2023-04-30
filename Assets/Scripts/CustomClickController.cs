using TMPro;
using UnityEngine;

public class CustomClickController : MonoBehaviour
{
    public Camera mainCamera;
    public TextMeshProUGUI popupText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("okis!");
                ShowPopupText(hit.collider.transform.position);
            }
        }
    }

    public void ShowPopupText(Vector3 position)
    {
        popupText.transform.position = mainCamera.WorldToScreenPoint(position);
        popupText.gameObject.SetActive(true);
        Invoke("HidePopupText", 2.0f);
    }

    private void HidePopupText()
    {
        popupText.gameObject.SetActive(false);
    }
}
