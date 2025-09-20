using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Private
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed;  // Player Movement Speed
    [SerializeField] private float jumpHeight; // Player jump Height

    [SerializeField] LayerMask groundLayer;  // Ground Layer and also for bubble
    [SerializeField] Transform groundCheck;  // Ground check inside the player

    private Rigidbody2D rb;  // Player Rigidbody
    private PlayerInput playerInput; // Player Input system
    private InputAction moveAction;  // Move input action
    private InputAction jumpAction;  // Jump Input Action

    private Vector2 moveDirection;  // Player move Direction

    [SerializeField] private Menus menus;  // Menus Scripts

    // Public

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();  // Getting player input
        moveAction = playerInput.currentActionMap.FindAction("Move");  //  Getting move input action
        jumpAction = playerInput.currentActionMap.FindAction("Jump");  //  Getting jump input action
        rb = GetComponent<Rigidbody2D>();  // Getting rigidbody
    }

    private void Start()
    {
        if (playerInput != null)
        {
            playerInput.ActivateInput();  // If the player input deactivated before reload it will get activated here
        }
    }

    private void FixedUpdate()
    {
        Movements(); // Calling movement method
    }

    private void OnEnable()
    {
        moveAction.Enable();  // Enabling move action
        jumpAction.performed += OnJumpPerformed;  // enabling jump method when space pressed
    }

    private void OnDisable()
    {
        moveAction.Disable();  // Disabling move action
        jumpAction.performed -= OnJumpPerformed;  // disabling jump method
    }

    // method for player movement
    private void Movements()
    {
        moveDirection = moveAction.ReadValue<Vector2>();  // reading input value
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);  // moving player by rigidbody velocity

    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {

        // If the player in the ground or bubble then only they can able to jump
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);  // Adding force for jump
        }
    }


    // method to check is grounded
    private bool IsGrounded()
    {
        // Using physics overlaps for ground check with the ground layer
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.5f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //  checking for bottom collider, if the player touch it, then it is game over
        if (collision.gameObject.tag == "BottomCollider")
        {
            menus.GameOver(); // Calling gameover in menus script
        }
    }

}
