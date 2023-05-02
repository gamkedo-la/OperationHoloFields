using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private RespawnScript respawn;
    public GameObject checkpointRings;
    

    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }


    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;
            checkpointRings.GetComponent<CheckpointColorChange>().checkpointColorOn = true;
        }
    }
}
