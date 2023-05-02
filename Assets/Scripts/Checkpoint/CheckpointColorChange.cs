using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointColorChange : MonoBehaviour
{
    public bool checkpointColorOn = false;
    public Material[] material;
    Renderer rend;

    private RespawnScript respawn;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    void Update()
    {
     if (checkpointColorOn == true)
        {
            rend.sharedMaterial = material[1];
        } else
        {
            rend.sharedMaterial = material[0];
        }
    }
}
