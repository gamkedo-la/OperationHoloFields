using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] float rotationSensitivity = 10f;

    private Vector2 rotationAmount;
    private float upDownRotation = 0f;

    [SerializeField] float interactDistance = 2f;

    public GameObject currentInteractableObject = null;
    public InteractableObjectScript currentInteractableObjectScript;
    public MeshRenderer currentInteractableObjectMeshRenderer;
    public GameObject[] arrayOfInteractableObjects;

    private PlayerGrab playerGrabScript;

    public void OnLook(InputAction.CallbackContext context)
    {
        rotationAmount = context.ReadValue<Vector2>();
    }

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
        Cursor.visible = false;

        upDownRotation = 0f;
        arrayOfInteractableObjects = GameObject.FindGameObjectsWithTag("Interactable");

        playerGrabScript = gameObject.transform.GetComponent<PlayerGrab>();
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


        //highlight interactable objects when in range
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance) && hit.transform.tag == "Interactable")
        {
            currentInteractableObject = hit.transform.gameObject;

            if (currentInteractableObject.name == "SinglePressButton (1)")
            {
                playerGrabScript.shouldntDropStuff = true;
            }

            for (int i = 0; i < arrayOfInteractableObjects.Length; i++)
            {
                if (arrayOfInteractableObjects[i] == currentInteractableObject)
                {
                    currentInteractableObjectScript = currentInteractableObject.GetComponent<InteractableObjectScript>();
                    currentInteractableObjectMeshRenderer = currentInteractableObjectScript.childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>();

                    if (!currentInteractableObjectScript.GetIsHighlighted())
                    {
                        currentInteractableObjectScript.originalMaterial = currentInteractableObjectMeshRenderer.material;
                        currentInteractableObjectScript.SetIsHighlighted(true);
                    }
                    currentInteractableObjectMeshRenderer.material = currentInteractableObjectScript.interactableHighlightMaterial;
                }
                else
                {
                    InteractableObjectScript otherInteractableObjectScript = arrayOfInteractableObjects[i].GetComponent<InteractableObjectScript>();
                    if (otherInteractableObjectScript.GetIsHighlighted())
                    {
                        otherInteractableObjectScript.SetIsHighlighted(false);
                    }
                    otherInteractableObjectScript.childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>().material =
                        arrayOfInteractableObjects[i].GetComponent<InteractableObjectScript>().originalMaterial;
                }
            } 
        }
        else
        {
            for (int i = 0; i < arrayOfInteractableObjects.Length; i++)
            {
                InteractableObjectScript interactableObjectScript = arrayOfInteractableObjects[i].GetComponent<InteractableObjectScript>();
                if (interactableObjectScript.GetIsHighlighted())
                {
                    interactableObjectScript.SetIsHighlighted(false);
                }
                interactableObjectScript.childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>().material =
                        interactableObjectScript.originalMaterial;

                playerGrabScript.shouldntDropStuff = false;
            }
        }
    }
}
