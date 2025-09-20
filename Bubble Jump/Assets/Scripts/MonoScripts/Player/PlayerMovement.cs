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

    [SerializeField] private Menus menus;

    // Public

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.currentActionMap.FindAction("Move");
        jumpAction = playerInput.currentActionMap.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (playerInput != null)
        {
            playerInput.ActivateInput();
        }
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
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BottomCollider")
        {
            menus.GameOver();
        }
    }

}
