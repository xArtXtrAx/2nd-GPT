using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;
    private RectTransform contentRectTransform;
    private float spawnInterval = 1.0f;
    private float yOffset = 0;
    private float padding = 10;

    void Start()
    {
        contentRectTransform = GetComponent<RectTransform>();
        StartCoroutine(SpawnButtons());
    }

    IEnumerator SpawnButtons()
    {
        for (int i = 0; ; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, contentRectTransform);
            RectTransform buttonRectTransform = newButton.GetComponent<RectTransform>();

            buttonRectTransform.anchorMin = new Vector2(0, 1);
            buttonRectTransform.anchorMax = new Vector2(1, 1);
            buttonRectTransform.pivot = new Vector2(0.5f, 1);
            buttonRectTransform.offsetMin = new Vector2(padding, buttonRectTransform.offsetMin.y);
            buttonRectTransform.offsetMax = new Vector2(-padding, buttonRectTransform.offsetMax.y);

            float buttonHeight = buttonRectTransform.rect.height;
            yOffset += (i == 0) ? padding : buttonHeight;
            buttonRectTransform.anchoredPosition = new Vector2(0, -yOffset - padding * i);

            contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, yOffset + padding * (i + 1));

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
