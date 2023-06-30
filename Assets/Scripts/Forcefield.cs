using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{

    [SerializeField] bool holoEnabled;
    new Renderer renderer;
    new Collider collider;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        ToggleForcefield(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        HoloGoggles.OnHoloGogglesTriggered += HoloGoggles_OnHoloGogglesTriggered;
        
    }

    private void OnDestroy() {
        HoloGoggles.OnHoloGogglesTriggered -= HoloGoggles_OnHoloGogglesTriggered;
    }

    private void HoloGoggles_OnHoloGogglesTriggered(object sender, bool e)
    {
        ToggleForcefield(e);
    }

    private void ToggleForcefield(bool holoState)
    {
        if(renderer == null){
            return;
        }
        if (holoState == holoEnabled)
        {
            renderer.enabled = true;
            collider.enabled = true;
            return;
        }
        renderer.enabled = false;
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
