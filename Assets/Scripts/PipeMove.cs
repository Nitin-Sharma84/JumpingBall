using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dest = -12f;
    void Update()
    {
        // Move pipe left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Destroy pipe when it goes off screen
        if (transform.position.x < dest)
        {
            Destroy(gameObject);
        }
    }
}
