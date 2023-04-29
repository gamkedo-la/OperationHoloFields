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

    public void OnLook(InputAction.CallbackContext context)
    {
        rotationAmount = context.ReadValue<Vector2>();
    }

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        upDownRotation = 0f;
        arrayOfInteractableObjects = GameObject.FindGameObjectsWithTag("Interactable");
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
            for (int i = 0; i < arrayOfInteractableObjects.Length; i++)
            {
                if (arrayOfInteractableObjects[i] == currentInteractableObject)
                {
                    currentInteractableObjectScript = currentInteractableObject.GetComponent<InteractableObjectScript>();
                    currentInteractableObjectMeshRenderer = currentInteractableObjectScript.childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>();
                    currentInteractableObjectMeshRenderer.material = currentInteractableObjectScript.interactableHighlightMaterial;
                }
                else
                {
                    arrayOfInteractableObjects[i].GetComponent<InteractableObjectScript>().childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>().material =
                        arrayOfInteractableObjects[i].GetComponent<InteractableObjectScript>().originalMaterial;
                }
            } 
        }
        else
        {
            for (int i = 0; i < arrayOfInteractableObjects.Length; i++)
            {
                arrayOfInteractableObjects[i].GetComponent<InteractableObjectScript>().childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>().material =
                        arrayOfInteractableObjects[i].GetComponent<InteractableObjectScript>().originalMaterial;
            }
        }
    }
}
