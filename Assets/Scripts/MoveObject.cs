using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5f;
    public bool useDeltaTime = true;

    void Update()
    {
        float moveAmount = speed * (useDeltaTime ? Time.deltaTime : 1);
        transform.position += new Vector3(moveAmount, 0, 0);
    }
}
