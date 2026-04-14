using UnityEngine;

public class BallJump : MonoBehaviour
{
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    public AudioClip jumpSound;

    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.linearVelocity = Vector2.zero;   // reset velocity
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioSource.PlayOneShot(jumpSound);
    }
}
