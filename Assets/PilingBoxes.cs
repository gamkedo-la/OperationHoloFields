using UnityEngine;

public class PilingBoxes : MonoBehaviour
{
    [SerializeField] Grabbable cubeToPileOnTop;
    [SerializeField] float cubeToPileSpeed = 10f;
    private bool otherCubeIsMoving = false;

    private void Update() 
    {
        if (!otherCubeIsMoving) return;

        cubeToPileOnTop.transform.localPosition = Vector3.MoveTowards(
            cubeToPileOnTop.transform.localPosition, 
            Vector3.up, 
            cubeToPileSpeed * Time.deltaTime
        );
        
        if (Vector3.Distance(cubeToPileOnTop.transform.localPosition, Vector3.up) < 1e-3) otherCubeIsMoving = false;
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject != cubeToPileOnTop.gameObject) return;
        
        if (cubeToPileOnTop.GetIsGrabbed())
        {
            FindObjectOfType<PlayerGrab>().Drop();
        }

        other.gameObject.tag = "Untagged";
        other.gameObject.GetComponent<Grabbable>().SetGrabEnabled(false);
        other.transform.SetParent(transform);
        other.GetComponent<Rigidbody>().useGravity = false;
        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        other.transform.localPosition = new Vector3(
            other.transform.localPosition.x,
            1.0f,
            other.transform.localPosition.z
        );

        otherCubeIsMoving = true;
    }
}
