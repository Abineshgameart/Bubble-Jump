using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Private
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveDirection;



    // Public

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.currentActionMap.FindAction("Move");
        jumpAction = playerInput.currentActionMap.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movements();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.performed -= OnJumpPerformed;
    }

    private void Movements()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
        rb.velocity = new Vector2(moveDirection.x * moveSpeed * 100 * Time.deltaTime, rb.velocity.y);

    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight * 100 * Time.deltaTime);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }


}
