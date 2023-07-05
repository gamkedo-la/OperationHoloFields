using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class RespawnScript : MonoBehaviour
{

    public static event EventHandler OnRespawn;

    [SerializeField] public CharacterController player;
    [SerializeField] public GameObject respawnPoint;
    [SerializeField] float deathFadeTime = 1f;
    private Fader fader;


    private void Awake() {
        if (player == null)
        {
            player = FindObjectOfType<CharacterController>();
        }

        fader = FindObjectOfType<Fader>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(KillPlayer());
            OnRespawn?.Invoke(this, EventArgs.Empty);
        }
    }

    private void TeleportPlayer()
    {
        player.enabled = false;
        player.transform.position = respawnPoint.transform.position;
        player.enabled = true;
    }

    public void UpdateRespawnPoint(GameObject newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    private IEnumerator KillPlayer()
    {
        InputActionAsset actions = player.gameObject.GetComponent<PlayerInput>().actions;
        actions.FindActionMap("Player").Disable();
        actions.FindActionMap("DeadPlayer").Enable();

        fader.ActivateFadeOutFadeInAtSpeed(deathFadeTime);
        yield return new WaitForSeconds(deathFadeTime / 2);

        TeleportPlayer();
        
        yield return new WaitForSeconds(deathFadeTime / 2);

        actions.FindActionMap("Player").Enable();
        actions.FindActionMap("DeadPlayer").Disable();
    }

}
