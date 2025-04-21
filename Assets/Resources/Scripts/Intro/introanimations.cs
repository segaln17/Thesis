using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introanimations : MonoBehaviour
{
    public GameObject flames;
    public Animator rightHand;
    public Animator leftHand;
    public Animator lizardHand;

    public GameObject songManager;
    public GameObject introLine;

    public AudioSource audioEffects;
    public AudioSource audioEffects02;
    public AudioClip burnSound;
    public AudioClip sparkleSound;

    public AudioClip walkingSound;

    public void flamesOn()
    {
        flames.SetActive(true);

    }
    public void flamesOff()
    {
        flames.SetActive(false);

    }

    public void activateSongManager()
    {
        songManager.SetActive(true);
        introLine.SetActive(true);


    }
    public void fadeHand()
    {
        lizardHand.Play("lizardfade");
        leftHand.Play("lefthandfade");
    }

    public void walkingSoundStart()
    {
        audioEffects.PlayOneShot(walkingSound);
    }

    public void burnsoundStart()
    {
        audioEffects.PlayOneShot(burnSound);
        audioEffects02.PlayOneShot(sparkleSound);
    }
}
