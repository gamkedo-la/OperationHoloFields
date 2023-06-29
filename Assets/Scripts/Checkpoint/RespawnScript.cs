using System;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{

    public static event EventHandler OnRespawn;

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
            OnRespawn?.Invoke(this, EventArgs.Empty);
        }
    }

    public void UpdateRespawnPoint(GameObject newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }
}
