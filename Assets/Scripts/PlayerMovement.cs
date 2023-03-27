using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float maxJumpHeight = 3f;
    [SerializeField] float maxJumpTime = 3f;

    private Vector2 moveAmount;
    private CharacterController characterController;
    private Vector3 playerVelocity = new Vector3(0, 0, 0);

    private bool isJumping = false;
    private bool isJumpPressed = false;
    private float gravityWhileJumping;
    private float initialJumpVelocityY;
    
    private void Awake() {
        characterController = GetComponent<CharacterController>();
        SetJumpParameters();
    }

    private void SetJumpParameters()
    {
        float timeToMaxJumpHeight = maxJumpTime / 2;
        gravityWhileJumping = -2f * maxJumpHeight / (timeToMaxJumpHeight * timeToMaxJumpHeight);
        initialJumpVelocityY = -gravityWhileJumping * timeToMaxJumpHeight;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        ProcessGravity();
        ProcessJump();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Debug.Log($"Phase {context.phase} - Trigger {context.action.triggered} - Value {context.ReadValueAsButton()}");

        if (characterController.isGrounded && context.performed)
        {
            Debug.Log("Jumping!");
            isJumpPressed = true;
        }
        else if (context.canceled)
        {
            Debug.Log("Landing");
            isJumpPressed = false;
        }
    }

    private void ProcessGravity()
    {
        if (characterController.isGrounded)
        {
            playerVelocity.y = -0.05f;
        }
        else
        {
            playerVelocity.y += gravityWhileJumping * Time.deltaTime;
        }
    }

    private void ProcessJump()
    {
        // if (characterController.isGrounded && playerVelocity.y <= 0) return;

        // Changes the height position of the player
        if (isJumpPressed && characterController.isGrounded && !isJumping)
        {
            isJumping = true;
            playerVelocity.y = initialJumpVelocityY;
        }
        else if (!isJumpPressed && characterController.isGrounded && isJumping)
        {
            isJumping = false;
        }
    }

    private void Move()
    {
        Vector3 movementSpeed = moveAmount.x * transform.right + moveAmount.y * transform.forward;
        movementSpeed *= moveSpeed;
        playerVelocity.x = movementSpeed.x;
        playerVelocity.z = movementSpeed.z;
        characterController.Move(playerVelocity  * Time.deltaTime);
    }
}
