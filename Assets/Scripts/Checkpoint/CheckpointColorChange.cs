using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointColorChange : MonoBehaviour
{
    private int ringMat = 0;
    public Material[] material;
    Renderer rend;

    private RespawnScript respawn;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[ringMat];
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
