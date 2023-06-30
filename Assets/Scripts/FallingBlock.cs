using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{

    [SerializeField] bool fallingBlock = true;
    [SerializeField] GameObject particleGO;
    Rigidbody rb;

    MeshRenderer visual;

    bool falling = false;
    float fallTime = 0;
    float fallTimeBeforeDeletion = 5f;

    Vector3 startPos;

    public bool IsFallingBlock { get => fallingBlock; }

    // Start is called before the first frame update
    void Start()
    {
        HoloGoggles.OnHoloGogglesTriggered += HoloGoggles_OnHoloGogglesTriggered;
        RespawnScript.OnRespawn += RespawnScript_OnRespawn;
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        visual = GetComponentInChildren<MeshRenderer>();
    }

    private void OnDestroy() {
        HoloGoggles.OnHoloGogglesTriggered -= HoloGoggles_OnHoloGogglesTriggered;
        RespawnScript.OnRespawn -= RespawnScript_OnRespawn;
    }

    private void RespawnScript_OnRespawn(object sender, EventArgs e)
    {
        ReenableBlock();
    }

    private void HoloGoggles_OnHoloGogglesTriggered(object sender, bool e)
    {
        OnHoloToggle(e);
    }

    public void OnHoloToggle(bool holoState)
    {
        if (!IsFallingBlock)
        {
            particleGO.SetActive(holoState);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!falling)
        {
            return;
        }

        fallTime += Time.deltaTime;

        if (fallTime > fallTimeBeforeDeletion)
        {
            DisableBlock();
        }
    }

    private void DisableBlock()
    {
        rb.isKinematic = true;
        visual.enabled = false;
        falling = false;
        fallTime = 0;
    }

    private void ReenableBlock()
    {
        rb.isKinematic = true;
        transform.position = startPos;
        falling = false;
        fallTime = 0;
        visual.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }

        if (!fallingBlock)
        {
            return;
        }

        rb.isKinematic = false;
        falling = true;
    }
}
