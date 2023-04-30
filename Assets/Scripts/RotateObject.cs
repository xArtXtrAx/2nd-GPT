using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public bool useDeltaTime = true;

    void Update()
    {
        float rotationAmount = rotationSpeed * (useDeltaTime ? Time.deltaTime : 1);
        transform.Rotate(0, 0, rotationAmount);
    }
}
