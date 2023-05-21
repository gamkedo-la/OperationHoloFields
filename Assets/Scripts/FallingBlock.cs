using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{

    [SerializeField] bool fallingBlock = true;
    Rigidbody rb;

    public bool IsFallingBlock { get => fallingBlock; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag != "Player"){
            return;
        }

        if(!fallingBlock){
            return;
        }

        rb.isKinematic = false;
        
    }
}
