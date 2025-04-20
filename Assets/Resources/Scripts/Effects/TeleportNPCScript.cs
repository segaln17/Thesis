using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TeleportNPCScript : MonoBehaviour
{
    public GameObject character;

    public GameObject targetSpot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand ("moveNPC")]
    public void MoveCharacter()
    {
        character.transform.position = targetSpot.transform.position;
        character.transform.localRotation = targetSpot.transform.localRotation;
    }
}
