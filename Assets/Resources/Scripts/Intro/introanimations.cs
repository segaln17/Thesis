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
}
