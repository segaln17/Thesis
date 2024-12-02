using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    public Animator fighterFeet;
    public GameObject controllerPlayer;
    public bool walkingTracker;

    public void Start()
    {
        walkingTracker = controllerPlayer.GetComponent<SimpleController>().isPlayerWalking;
    }

    public void Update()
    {
        walkingTracker = controllerPlayer.GetComponent<SimpleController>().isPlayerWalking;
        
        if (walkingTracker)
        {
            feetWalking();
        }
        else if (!walkingTracker)
        {
            feetStill();
        }
    }

    public void feetStill()
    {
        fighterFeet.SetBool("feetWalking", false);
    }

    public void feetWalking()
    {
        fighterFeet.SetBool("feetWalking", true);
    }
}
