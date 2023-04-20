using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType { Landing, Running, Swimming, Walking }
public enum MaterialsurfaceType { Dirt, Hard, MetalGrate }

public class MovementSoundController : MonoBehaviour
{
    [SerializeField] GameObject hardFootSounds;

    private AudioSource[] walkHardFootSoundsFootSounds;

    private AudioSource soundToPlay;

    void Awake()
    {
        walkHardFootSoundsFootSounds = hardFootSounds.transform.Find("WalkingSounds").GetComponents<AudioSource>();
    }

    public void PlayMoveSound(MaterialsurfaceType surfaceType, MovementType footStep)
    {
        if(surfaceType == MaterialsurfaceType.Hard) {
            if(footStep == MovementType.Walking) { soundToPlay = walkHardFootSoundsFootSounds[Random.Range(0, walkHardFootSoundsFootSounds.Length - 1)]; }
        }
        else { soundToPlay = walkHardFootSoundsFootSounds[Random.Range(0, walkHardFootSoundsFootSounds.Length - 1)]; }

        soundToPlay.pitch = Random.Range(0.75f, 1.5f);
        soundToPlay.Play();
    }

}