using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public float colorSpeed = 0.5f;
    public bool useDeltaTime = true;
    private bool increasingAlpha = false;
    private float newAlpha;

    void Update()
    {

        float colorAmount = colorSpeed * (useDeltaTime ? Time.deltaTime : 1);
        Color currentColor = GetComponent<SpriteRenderer>().color;
        if (currentColor.a >= 1)
        {
            increasingAlpha = false;
        }
        else if (currentColor.a <= 0)
        {
            increasingAlpha = true;
        }

        if (increasingAlpha)
        {
            newAlpha = Mathf.Clamp(currentColor.a + colorAmount, 0, 1);
        }
        else
        {
            newAlpha = Mathf.Clamp(currentColor.a - colorAmount, 0, 1);
        }
        
        GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);
    }
}
