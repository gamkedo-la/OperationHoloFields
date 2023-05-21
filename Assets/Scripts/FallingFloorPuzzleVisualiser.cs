using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloorPuzzleVisualiser : MonoBehaviour
{

    [SerializeField] List<FallingBlock> blocks = new List<FallingBlock>();
    [SerializeField] bool showVisualisation = false;

    private void OnDrawGizmos()
    {
        if(!showVisualisation){
            return;
        }
        foreach (var block in blocks)
        {
            if(block == null){
                continue;
            }
            Gizmos.color = block.IsFallingBlock ? Color.red : Color.green;
            Vector3 blockPosition = block.transform.position;
            Vector3 visualisationPosition = new Vector3(blockPosition.x + block.transform.localScale.x/2, blockPosition.y + 1, blockPosition.z + block.transform.localScale.z/2);
            Gizmos.DrawCube(visualisationPosition, new Vector3(2, 1, 2));
        }
    }

    

}
