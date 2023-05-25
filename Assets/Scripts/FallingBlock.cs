using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{

    [SerializeField] bool fallingBlock = true;
    [SerializeField] GameObject particleGO;
    Rigidbody rb;

    bool falling = false;
    float fallTime = 0;
    float fallTimeBeforeDeletion = 5f;

    public bool IsFallingBlock { get => fallingBlock; }

    // Start is called before the first frame update
    void Start()
    {
        HoloGoggles.OnHoloGogglesTriggered += HoloGoggles_OnHoloGogglesTriggered;
        rb = GetComponent<Rigidbody>();
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
            Destroy(gameObject);
        }
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