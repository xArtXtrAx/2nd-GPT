using UnityEngine;

public class ShapeMovement : MonoBehaviour
{
    public Vector2 initialVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ScreenBounds"))
        {
            Camera.main.backgroundColor = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);
        }
    }
}
