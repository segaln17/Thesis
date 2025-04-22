using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BonfireCameraScript : MonoBehaviour
{
    //public GameObject outsideCutsceneObjs;
    public GameObject InsideCutsceneObjs;

    public CinemachineVirtualCamera bonfireCam;
    

    public bool inBonfireTrigger = false;
    public bool inBonfireCutscene = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inBonfireTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                inBonfireCutscene = true;
            }
        }

        if (inBonfireCutscene)
        {
            //outsideCutsceneObjs.SetActive(false);
            InsideCutsceneObjs.SetActive(true);
            bonfireCam.Priority = 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inBonfireTrigger = true;
    }
}
