using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public float scaleSpeed = 0.5f;
    public bool useDeltaTime = true;

    void Update()
    {
        float scaleAmount = scaleSpeed * (useDeltaTime ? Time.deltaTime : 1);
        transform.localScale += new Vector3(scaleAmount, scaleAmount, 0);
    }
}
