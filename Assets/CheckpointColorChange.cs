using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointColorChange : MonoBehaviour
{

    public Material[] material;
    Renderer rend;

    private RespawnScript respawn;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        //if (respawn.respawnPoint = gameObject.CheckPoint2)
       // {
       //     rend.sharedMaterial = material[1];
       // }
     
    }
}
