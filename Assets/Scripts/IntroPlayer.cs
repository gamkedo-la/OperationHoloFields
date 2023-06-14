using UnityEngine;
using UnityEngine.Playables;

public class IntroPlayer : MonoBehaviour
{
    private bool hasPlayed = false;
    private void OnTriggerEnter(Collider other) 
    {
        if (hasPlayed) return;
        if (!other.gameObject.CompareTag("Player")) return;

        GetComponent<PlayableDirector>().Play();
        hasPlayed = true;
    }
}
