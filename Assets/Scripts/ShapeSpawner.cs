using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeSpawner : MonoBehaviour
{
    public List<GameObject> shapePrefabs;
    private RectTransform contentRectTransform;
    private float spawnInterval = 1.0f;
    private float xOffset = 0;
    private float separation = 10;
    private float rotationSpeed = 60f;

    void Start()
    {
        contentRectTransform = GetComponent<RectTransform>();
        StartCoroutine(SpawnShapes());
    }

    IEnumerator SpawnShapes()
    {
        for (int i = 0; ; i++)
        {
            GameObject randomShape = shapePrefabs[Random.Range(0, shapePrefabs.Count)];
            GameObject newShape = Instantiate(randomShape, contentRectTransform);
            RectTransform shapeRectTransform = newShape.GetComponent<RectTransform>();

            shapeRectTransform.anchorMin = new Vector2(0, 0);
            shapeRectTransform.anchorMax = new Vector2(0, 1);
            shapeRectTransform.pivot = new Vector2(0.5f, 0.5f);

            float shapeWidth = shapeRectTransform.rect.width;
            xOffset += (i == 0) ? 0 : shapeWidth + separation;
            shapeRectTransform.anchoredPosition = new Vector2(xOffset, 0);
            shapeRectTransform.sizeDelta = new Vector2(shapeWidth, contentRectTransform.rect.height);

            contentRectTransform.sizeDelta = new Vector2(xOffset + shapeWidth + separation, contentRectTransform.sizeDelta.y);

            newShape.AddComponent<ShapeRotation>().rotationSpeed = rotationSpeed;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
