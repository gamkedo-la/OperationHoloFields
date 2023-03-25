using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] float rotationSensitivity = 10f;

    private Vector2 rotationAmount;
    private float upDownRotation = 0f;
    
    public void OnLook(InputAction.CallbackContext context)
    {
        rotationAmount = context.ReadValue<Vector2>();
    }

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        upDownRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the player look up / down
        upDownRotation -= rotationAmount.y * rotationSensitivity * Time.deltaTime;
        upDownRotation = Mathf.Clamp(upDownRotation, -90f, 90f);
        mainCamera.transform.localRotation = Quaternion.Euler(upDownRotation, 0, 0);

        // Rotate the player body
        transform.Rotate(Vector3.up, rotationAmount.x * rotationSensitivity * Time.deltaTime);
    }
}
