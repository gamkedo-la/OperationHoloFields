using UnityEngine;
using UnityEngine.SceneManagement;

public class EndParkourLevel : MonoBehaviour
{
    [SerializeField] string levelToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
