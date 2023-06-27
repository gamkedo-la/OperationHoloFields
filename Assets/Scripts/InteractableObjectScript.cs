using UnityEngine;

public class InteractableObjectScript : MonoBehaviour
{
    public Material originalMaterial;
    public Material interactableHighlightMaterial;
    public bool couldBeOrCurrentlyInteractedByPlayer = false;
    private GameObject childObjectWithActualMeshesAndMaterials;
    private GameObject myGameObject;
    private bool isHighLighted = false;
    public int materialIdxToChange = 0;
    
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
    
    public void ChangeMaterialToHighlighted()
    {
        Material[] allMaterials = childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>().materials;
        allMaterials[materialIdxToChange] = interactableHighlightMaterial;
        childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>().materials = allMaterials;
    }

    public void ChangeMaterialToOriginal()
    {
        Material[] allMaterials = childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>().materials;
        allMaterials[materialIdxToChange] = originalMaterial;
        childObjectWithActualMeshesAndMaterials.GetComponent<MeshRenderer>().materials = allMaterials;
    }
}
