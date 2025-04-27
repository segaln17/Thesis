using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class CustomCommands : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public GameObject player;

    public GameObject creature;

    public CinemachineVirtualCamera firstPOVusual;
    public CinemachineVirtualCamera firstPOVzoomed;

    public AudioSource soundSource;
    public AudioClip knock;
    public AudioClip doorClose;
    public AudioClip doorOpen;

    public void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        if (creature.CompareTag("Player") || creature.CompareTag("Moon"))
        {
            return;
        }
        else
        {
            creature.SetActive(false);
        }
        
        firstPOVzoomed.Priority = 1;
        //firstPOVusual.Priority = 12;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("revealCreature")]
    public void RevealCreature()
    {
        creature.SetActive(true);
    }

    [YarnCommand("disappearCreature")]
    public void DisappearCreature()
    {
        creature.SetActive(false);
    }

    [YarnCommand("colliderActive")]
    public void SetColliderActive()
    {
        //using creature as a stand in for the yarn collider
        creature.SetActive(true);
    }

    [YarnCommand("changeCam")]
    public void ChangeCameraZoom()
    {
        firstPOVusual.Priority = 1;
        firstPOVzoomed.Priority = 12;
    }

    [YarnCommand("changeBackCam")]
    public void ChangeBackCamera()
    {
        firstPOVusual.Priority = 12;
        firstPOVzoomed.Priority = 1;
    }

    [YarnCommand("playKnock")]
    public void PlayKnock()
    {
        soundSource.PlayOneShot(knock);
    }

    [YarnCommand("closeDoor")]
    public void DoorClose()
    {
        soundSource.PlayOneShot(doorClose);
    }

    [YarnCommand("openDoor")]
    public void DoorOpen()
    {
        soundSource.PlayOneShot(doorOpen);
    }

    [YarnCommand("restart")]
    public void RestartGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
