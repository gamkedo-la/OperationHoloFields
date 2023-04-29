using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectScript : MonoBehaviour
{
    public Material originalMaterial;
    public Material interactableHighlightMaterial;
    public bool couldBeOrCurrentlyInteractedByPlayer = false;
    public GameObject childObjectWithActualMeshesAndMaterials;
    public GameObject myGameObject;

    // Start is called before the first frame update
    void Start()
    {
        childObjectWithActualMeshesAndMaterials = gameObject.transform.GetChild(0).gameObject;
        myGameObject = gameObject;
    }

    
}
