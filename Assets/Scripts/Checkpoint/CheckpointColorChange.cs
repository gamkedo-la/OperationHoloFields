using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointColorChange : MonoBehaviour
{
    public bool checkpointColorOn = false;
    //private int ringMat = 0;
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
     if (checkpointColorOn == true)
        {
            rend.sharedMaterial = material[1];
        } else
        {
            rend.sharedMaterial = material[0];
        }
    }
}
