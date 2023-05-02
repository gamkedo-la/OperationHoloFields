using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private RespawnScript respawn;
    public GameObject checkpointRing1;
    public GameObject checkpointRing2;


    void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }


    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = this.gameObject;
            checkpointRing1.GetComponent<CheckpointColorChange>().checkpointColorOn = true;
            checkpointRing2.GetComponent<CheckpointColorChange>().checkpointColorOn = true;
        }
    }

    void Update ()
    {
        if (respawn.respawnPoint != this.gameObject) {
            checkpointRing1.GetComponent<CheckpointColorChange>().checkpointColorOn = false;
            checkpointRing2.GetComponent<CheckpointColorChange>().checkpointColorOn = false;
        }
    }
}
