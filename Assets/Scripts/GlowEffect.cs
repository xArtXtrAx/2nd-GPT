using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GlowEffect : MonoBehaviour
{
    public float glowInterval = 5.0f;
    public float glowDuration = 1.0f;
    public Color glowColor = new Color(1, 1, 1, 0.4f);
    private Image glowImage;

    void Start()
    {
        // Create a new Image GameObject as a child of the button
        GameObject glowObject = new GameObject("Glow");
        glowObject.transform.SetParent(transform, false);
        glowObject.transform.SetAsFirstSibling(); // Place the glow object below the button

        // Set up the Image component and the glowing material
        glowImage = glowObject.AddComponent<Image>();
        glowImage.material = new Material(Shader.Find("Custom/UnlitColorTexture"));
        glowImage.material.color = glowColor;
        glowImage.rectTransform.anchorMin = new Vector2(0, 0);
        glowImage.rectTransform.anchorMax = new Vector2(1, 1);
        glowImage.rectTransform.offsetMin = new Vector2(0, 0);
        glowImage.rectTransform.offsetMax = new Vector2(0, 0);

        // Start the glowing effect
        StartCoroutine(GlowCoroutine());
    }

    IEnumerator GlowCoroutine()
    {
        while (true)
        {
            // Fade in the glow
            float elapsedTime = 0;
            while (elapsedTime < glowDuration / 2)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(0, glowColor.a, elapsedTime / (glowDuration / 2));
                glowImage.material.color = new Color(glowColor.r, glowColor.g, glowColor.b, alpha);
                yield return null;
            }

            // Fade out the glow
            elapsedTime = 0;
            while (elapsedTime < glowDuration / 2)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(glowColor.a, 0, elapsedTime / (glowDuration / 2));
                glowImage.material.color = new Color(glowColor.r, glowColor.g, glowColor.b, alpha);
                yield return null;
            }

            // Wait for the next glow
            yield return new WaitForSeconds(glowInterval - glowDuration);
        }
    }
}
