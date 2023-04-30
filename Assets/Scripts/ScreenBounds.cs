using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z));
        Vector2 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -Camera.main.transform.position.z));
        Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -Camera.main.transform.position.z));
        Vector2 bottomRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -Camera.main.transform.position.z));
        EdgeCollider2D edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        Vector2[] edgePoints = new Vector2[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
        edgeCollider.points = edgePoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
