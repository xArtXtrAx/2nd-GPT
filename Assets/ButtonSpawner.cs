using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;
    private RectTransform contentRectTransform;
    private float spawnInterval = 1.0f;
    private float yOffset = 0;

    void Start()
    {
        contentRectTransform = GetComponent<RectTransform>();
        StartCoroutine(SpawnButtons());
    }

    IEnumerator SpawnButtons()
    {
        for (int i = 0; i < 10; i++) // Change 10 to the desired number of buttons
        {
            GameObject newButton = Instantiate(buttonPrefab, contentRectTransform);
            RectTransform buttonRectTransform = newButton.GetComponent<RectTransform>();

            buttonRectTransform.anchorMin = new Vector2(0, 1);
            buttonRectTransform.anchorMax = new Vector2(1, 1);
            buttonRectTransform.pivot = new Vector2(0.5f, 1);

            // Set the position of the button relative to the previous button
            float buttonHeight = buttonRectTransform.rect.height;
            yOffset += buttonHeight;
            buttonRectTransform.anchoredPosition = new Vector2(0, -yOffset);

            // Update the content size to fit the new button
            contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, yOffset);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

