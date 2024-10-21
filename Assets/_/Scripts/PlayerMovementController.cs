using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;           // Movement speed of the player.
    public float jumpForce = 7f;           // Force applied when the player jumps.
    private Rigidbody2D rb;                // Reference to the player's Rigidbody2D component.
    private bool isGrounded;               // Check if the player is grounded.
    private Transform groundCheck;         // Reference to the ground check position.
    private LayerMask groundLayer;         // Layer mask for the ground objects.
    private bool isFacingRight = true;     // Flag to track the direction the player is facing.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();                  // Get the Rigidbody2D component of the player.
        groundCheck = transform.Find("GroundCheck");       // Find the ground check position.
        groundLayer = LayerMask.GetMask("Ground");          // Set the ground layer (change to your ground layer name).
        rb.freezeRotation = true;                           // Lock the character's rotation.
    }

    private void Update()
    {
        // Check if the player is grounded.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Player movement
        float moveDirection = Input.GetAxis("Horizontal"); // Get the horizontal input (left or right).
        rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y); // Apply horizontal velocity.

        // Flip the character's direction if necessary.
        if (moveDirection > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipCharacter();
        }

        // Player jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply jump force if grounded and Space key is pressed.
        }
    }

    // Function to flip the character's direction.
    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;             // Toggle the facing direction flag.

        Vector3 scale = transform.localScale;       // Get the current local scale.
        scale.x *= -1;                             // Invert the X scale to flip horizontally.
        transform.localScale = scale;               // Apply the new local scale to flip the character.
    }
}
