using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathZone : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    [SerializeField] private Transform respawn_point;

    private void OnTriggerEnter(Collider other)
    {
        player.enabled = false;
        player.transform.position = respawn_point.transform.position;
        Debug.Log("back to checkpoint!");
        player.enabled = true;
    }
}
