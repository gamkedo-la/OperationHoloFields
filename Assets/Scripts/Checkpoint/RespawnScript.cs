using UnityEngine;

public class RespawnScript : MonoBehaviour
{

    [SerializeField] public CharacterController player;
    [SerializeField] public GameObject respawnPoint;

    private void Awake() {
        if (player == null)
        {
            player = FindObjectOfType<CharacterController>();
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("chekcpoint");
            player.enabled = false;
            player.transform.position = respawnPoint.transform.position;
            player.enabled = true;
        }
    }
}
