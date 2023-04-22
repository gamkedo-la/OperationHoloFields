using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    //public GameObject player;
    //public GameObject respawnPoint;

    [SerializeField] public CharacterController player;
    [SerializeField] public GameObject respawnPoint;

    private void Awake() {
        if (player == null)
        {
            player = FindObjectOfType<CharacterController>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("chekcpoint");
            player.enabled = false;
            player.transform.position = respawnPoint.transform.position;
            player.enabled = true;
        }
    }
}
