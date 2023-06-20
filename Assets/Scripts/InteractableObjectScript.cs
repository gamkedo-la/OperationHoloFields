using UnityEngine;

public class InteractableObjectScript : MonoBehaviour
{
    public Material originalMaterial;
    public Material interactableHighlightMaterial;
    public bool couldBeOrCurrentlyInteractedByPlayer = false;
    private GameObject childObjectWithActualMeshesAndMaterials;
    private GameObject myGameObject;
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

    public GameObject GetChildWithMesh()
    {
        return childObjectWithActualMeshesAndMaterials;
    }
    
}
