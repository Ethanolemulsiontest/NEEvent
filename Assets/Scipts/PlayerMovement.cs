using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = movementJoystick.Direction;

        // Movement
        if (direction != Vector2.zero)
        {
            rb.linearVelocity = direction * playerSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        // Animation
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
        animator.SetBool("IsMoving", direction != Vector2.zero);
    }
}
