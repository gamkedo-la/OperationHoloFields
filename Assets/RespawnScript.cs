using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    //public GameObject player;
    //public GameObject respawnPoint;

    [SerializeField] private CharacterController player;
    [SerializeField] private Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
