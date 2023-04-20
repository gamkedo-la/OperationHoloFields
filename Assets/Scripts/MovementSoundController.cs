using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType { Landing, Running, Swimming, Walking }
public enum MaterialSurfaceType { Dirt, Hard, MetalGrate }

public class MovementSoundController : MonoBehaviour
{
    [SerializeField] GameObject hardFootSounds;

    private AudioSource[] walkHardFootSounds;
    private AudioSource[] landHardFootSounds;

    private AudioSource soundToPlay;

    void Awake()
    {
        walkHardFootSounds = hardFootSounds.transform.Find("WalkingSounds").GetComponents<AudioSource>();
        landHardFootSounds = hardFootSounds.transform.Find("LandingSounds").GetComponents<AudioSource>();
    }

    public void PlayMoveSound(MaterialSurfaceType surfaceType, MovementType moveType)
    {
        if(surfaceType == MaterialSurfaceType.Hard) {
            if(moveType == MovementType.Walking) { soundToPlay = walkHardFootSounds[Random.Range(0, walkHardFootSounds.Length - 1)]; }
            else if(moveType == MovementType.Landing) { soundToPlay = landHardFootSounds[Random.Range(0, landHardFootSounds.Length - 1)]; }
        }

        soundToPlay.pitch = Random.Range(0.75f, 1.5f);
        soundToPlay.Play();
    }

}