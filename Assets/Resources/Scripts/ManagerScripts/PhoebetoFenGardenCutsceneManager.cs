using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PhoebetoFenGardenCutsceneManager : MonoBehaviour
{
    [Header("Yarn Triggers")]
    public DialogueTrigger outsideRookeryTrigger;
    public GameObject coroutineManager;

    

    // Start is called before the first frame update
    void Start()
    {

        
      
    }

    // Update is called once per frame
    void Update()
    {
        if (outsideRookeryTrigger.dialoguePlayed)
        {
            StartCoroutine(coroutineManager.GetComponent<CutsceneCoroutineManager>().PtoFfromGarden());
            outsideRookeryTrigger.dialoguePlayed = false;
            
        }

      


    }

  
}
