using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CustomCommands : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public GameObject player;

    public GameObject creature;

    public void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        creature.SetActive(false);
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
}
