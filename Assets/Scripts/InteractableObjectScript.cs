using UnityEngine;

public class InteractableObjectScript : MonoBehaviour
{
    public Material originalMaterial;
    public Material interactableHighlightMaterial;
    public bool couldBeOrCurrentlyInteractedByPlayer = false;
    public GameObject childObjectWithActualMeshesAndMaterials;
    public GameObject myGameObject;
    private bool isHighLighted = false;

    // Start is called before the first frame update
    void Start()
    {
        childObjectWithActualMeshesAndMaterials = gameObject.transform.GetChild(0).gameObject;
        myGameObject = gameObject;
    }

    public void SetIsHighlighted(bool value)
    {
        isHighLighted = value;
    }

    public bool GetIsHighlighted()
    {
        return isHighLighted;
    }

    
}
