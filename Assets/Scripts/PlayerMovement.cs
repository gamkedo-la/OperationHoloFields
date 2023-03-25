using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float jumpHeight = 10f;

    private Vector2 moveAmount;
    private CharacterController characterController;
    private Vector3 playerVelocity = new Vector3(0, 0, 0);
    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (characterController.isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(-jumpHeight * 2f * Physics.gravity.y);
        }
    }

    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ProcessJump();
    }

    private void ProcessJump()
    {
        if (characterController.isGrounded && playerVelocity.y <= 0) return;

        // Changes the height position of the player
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    private void Move()
    {
        Vector3 movement = moveAmount.x * transform.right + moveAmount.y * transform.forward;
        movement *= moveSpeed * Time.deltaTime;
        characterController.Move(movement);
    }
}
