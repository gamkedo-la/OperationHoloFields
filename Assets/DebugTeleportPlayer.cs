using UnityEngine;

public class DebugTeleportPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] Transform locationButton1;
    [SerializeField] Transform locationButton2;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && locationButton1 != null)
        {
            print("Location one");
            TeleportPlayerToLocation(locationButton1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && locationButton2 != null)
        {
            print("Location two");
            TeleportPlayerToLocation(locationButton2);
        }
    }

    private void TeleportPlayerToLocation(Transform location)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = location.position;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
