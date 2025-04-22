using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseWalkSpeed : MonoBehaviour
{
    public SimpleController playerController;
    public float lighthouseForceFen = 1000f;
    public float groundForceFen = 775f;
    // Start is called before the first frame update
    void Start()
    {
        groundForceFen = playerController.force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        playerController.force = lighthouseForceFen;
    }
}
