using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float maxJumpHeight = 3f;
    [SerializeField] float maxJumpTime = 3f;
    [SerializeField] GameObject movementSoundHandler;
    [SerializeField] float SecsBetweenMoveSounds = 0.5f;

    private Vector2 moveAmount;
    private CharacterController characterController;
    private Vector3 playerVelocity = new Vector3(0, 0, 0);

    private float dashJumpSpeed = 1.5f;

    private bool isJumping = false;
    private bool isJumpPressed = false;
    private bool isLeaping = false;
    private bool wasFalling = false;
    private float gravityWhileJumping;
    private float initialJumpVelocityY;

    private MovementSoundController movementSounds;
    private float moveSoundCooldownTimer = 0f;

    [SerializeField] GameObject pauseMenu;
    public bool gameIsPaused = false;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        SetJumpParameters();
        movementSounds = movementSoundHandler.GetComponent<MovementSoundController>();

        //playerInputComponent = gameObject.GetComponent<PlayerInput>();
        //pauseMenuInputAction = playerInputComponent.TogglePause
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
        float airControlPerc = 1.0f;
        if (isLeaping)
        {
            airControlPerc = 0.0f;
        }
        else if (isJumping)
        {
            airControlPerc = 0.7f;
        }

        moveAmount = airControlPerc * context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Debug.Log($"Phase {context.phase} - Trigger {context.action.triggered} - Value {context.ReadValueAsButton()}");

        if (characterController.isGrounded && context.performed)
        {
            Debug.Log("Jumping!");
            isJumpPressed = true;
            bool isRunning = moveAmount.magnitude > 0.8f;
            if (isRunning)
            {
                moveAmount *= dashJumpSpeed;
                isLeaping = true;
            }
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
            if (wasFalling && playerVelocity.y < -5)
            {
                movementSounds.PlayMoveSound(MaterialSurfaceType.Hard, MovementType.Landing);
            }
            playerVelocity.y = -0.05f;
            wasFalling = false;
        }
        else
        {
            playerVelocity.y += gravityWhileJumping * Time.deltaTime;
            wasFalling = true;
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
            isLeaping = false;
            bool isRunning = moveAmount.magnitude > 0.8f;
            if (isRunning)
            {
                moveAmount /= dashJumpSpeed;
            }
        }
    }

    private void Move()
    {
        Vector3 movementSpeed = moveAmount.x * transform.right + moveAmount.y * transform.forward;
        movementSpeed *= moveSpeed;
        playerVelocity.x = movementSpeed.x;
        playerVelocity.z = movementSpeed.z;
        characterController.Move(playerVelocity  * Time.deltaTime);
        MovementSound();
    }

    private void MovementSound()
    {
        /*
         * Checks if a movement sound should be played.
         * If one should, it triggers the movement sound handler game object to play a sound.
         */

        if (characterController.isGrounded && characterController.velocity != Vector3.zero)
        {
            if (moveSoundCooldownTimer <= 0)
            {
                // This is hard coded to play ONE type of walking sound.
                // This should be updated as the types of noises and surfaces are added.
                // Uses enums that are globally defined in the MovementSoundController.cs script
                movementSounds.PlayMoveSound(MaterialSurfaceType.Hard, MovementType.Walking);
                moveSoundCooldownTimer = SecsBetweenMoveSounds;
            }
        }

        moveSoundCooldownTimer -= Time.deltaTime;
    }

    public void TogglePause()
    {
        Debug.Log("p key recognized");
        if (!gameIsPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            gameIsPaused = true;
        }
        else if (gameIsPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
        }
    }

}
