using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;

    // Joystick only works when this is true
    public bool joystickActive = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystickActive = false;
    }

    private void FixedUpdate()
    {
        // Stop the player completely if joystick is disabled
        if (!joystickActive)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (movementJoystick.Direction != Vector2.zero)
        {
            rb.linearVelocity = new Vector2(
                movementJoystick.Direction.x * playerSpeed,
                movementJoystick.Direction.y * playerSpeed
            );
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}