using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
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
