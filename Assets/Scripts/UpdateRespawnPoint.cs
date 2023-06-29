using UnityEngine;

public class UpdateRespawnPoint : MonoBehaviour
{
    [SerializeField] RespawnScript respawnObject;
    private bool isCheckPoint = false;

    private void Start() {
        if (respawnObject.respawnPoint == this.gameObject)
        {
            isCheckPoint = true;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (isCheckPoint) return;

        if(other.CompareTag("Player"))
        {
            respawnObject.UpdateRespawnPoint(this.gameObject);
            isCheckPoint = true;
        }
    }

}
