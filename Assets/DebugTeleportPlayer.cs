using UnityEngine;

public class DebugTeleportPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] Transform[] locationButtons;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && locationButtons.Length > 0)
        {
            TeleportPlayerToLocation(locationButtons[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && locationButtons.Length > 1)
        {
            TeleportPlayerToLocation(locationButtons[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && locationButtons.Length > 2)
        {
            TeleportPlayerToLocation(locationButtons[2]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && locationButtons.Length > 3)
        {
            TeleportPlayerToLocation(locationButtons[3]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && locationButtons.Length > 4)
        {
            TeleportPlayerToLocation(locationButtons[4]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && locationButtons.Length > 5)
        {
            TeleportPlayerToLocation(locationButtons[5]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) && locationButtons.Length > 6)
        {
            TeleportPlayerToLocation(locationButtons[6]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) && locationButtons.Length > 7)
        {
            TeleportPlayerToLocation(locationButtons[7]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9) && locationButtons.Length > 8)
        {
            TeleportPlayerToLocation(locationButtons[8]);
        }
    }

    private void TeleportPlayerToLocation(Transform location)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = location.position;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
