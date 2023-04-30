using UnityEngine;

public class ShapeRotation : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
