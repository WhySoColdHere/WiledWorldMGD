using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float jumpForce;
    public Vector2 moveInput;

    [Header("Ground check")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isGrounded;

    [Header("IdkHowToNameThisHeader")]
    private int facingDirection = 1;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerInput playerInput;

    void Update()
    {
        CheckGrounded();
        Flip();
    }

    void FixedUpdate()
    {
        // If player input is 'A', then moveInput.x will be equals to -1, if 'D', then moveInput.x == 1, else moveInput.x == 0.
        // Thats why we are multiplying speed by moveInput.x, to move character in the current direction with speed.
        float targetSpeed = moveInput.x * speed;
        rb.linearVelocity = new Vector2(targetSpeed, rb.linearVelocity.y);
    }

    public void Flip() 
    {
        if (moveInput.x > 0.1f)
        {
            facingDirection = 1;
        } 
        else if (moveInput.x < -0.1f) 
        {
            facingDirection = -1;
        }

        transform.localScale = new Vector3(facingDirection, 1, 1);
    }

    public void CheckGrounded() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void OnMove(InputValue val)
    {
        moveInput = val.Get<Vector2>();
    }

    public void OnJump(InputValue val)
    {
        if (val.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    public void OnDrawGizmosSeelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
