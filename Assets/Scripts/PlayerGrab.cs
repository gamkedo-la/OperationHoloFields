using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{

    Grabbable grabbedObject;
    [SerializeField] Transform grabLocation;
    float grabTimer = 0f;
    Rigidbody grabbedObjectRigidBody;

    public bool shouldntDropStuff = false;

    float minGrabTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        grabTimer += Time.deltaTime;




    }

    private void FixedUpdate()
    {
        if (grabbedObject == null)
        {
            return;
        }

        float lerpSpeed = 10f;
        Vector3 newPosition = Vector3.Lerp(grabbedObject.transform.position, grabLocation.position, Time.deltaTime * lerpSpeed);

        if (grabbedObjectRigidBody == null)
        {
            grabbedObject.transform.position = newPosition;
            return;
        }

        grabbedObjectRigidBody.MovePosition(newPosition);

    }


    public void Grab(Grabbable grabbedObject)
    {
        if (!CanGrab() || grabTimer < minGrabTime)
        {
            return;
        }

        this.grabbedObject = grabbedObject;
        if (grabbedObject.TryGetComponent<Rigidbody>(out grabbedObjectRigidBody))
        {
            grabbedObjectRigidBody.useGravity = false;
            grabbedObjectRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        grabTimer = 0f;
    }

    public bool CanGrab()
    {
        return grabbedObject == null;
    }

    public void Drop()
    {
        if (shouldntDropStuff)
        {
            return;
        }

        if (grabbedObjectRigidBody != null)
        {
            grabbedObjectRigidBody.velocity = Vector3.zero;
            grabbedObjectRigidBody.useGravity = true;
            grabbedObjectRigidBody.constraints = RigidbodyConstraints.None;
        }
        grabbedObject = null;
        grabTimer = 0f;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (grabbedObject == null || grabTimer < minGrabTime)
        {
            return;
        }

        Drop();

    }
}
