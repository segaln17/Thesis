using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;
using UnityEngine.Events;

public class YarnDialogueTrigger : MonoBehaviour
{
    public string nodeToCall;
    public GameObject fighter;
    public GameObject diviner;
    //public GameObject cleric;

    public bool inYarnTrigger;

    public bool cutsceneRun = false;

   
    public GameManager gameManager;
    

    public TextMeshProUGUI dialogueIndicator;
    

    // Start is called before the first frame update
    void Start()
    {
        dialogueIndicator.gameObject.SetActive(false);
        inYarnTrigger = false;
       // gameSetCharacterPOV(GameManager.CharacterPOV.Fighter);

        //cutsceneRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Cutscene"))
        {
            if (!cutsceneRun)
            {
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                {
                    FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
                    
                }
                cutsceneRun = true;
            }
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inYarnTrigger)
                {
                    Debug.Log("talking");
                    dialogueIndicator.gameObject.SetActive(false);
                    if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                    {
                        FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
                    }
                
                }

            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Cutscene"))
            {
                dialogueIndicator.gameObject.SetActive(false);
            }
            else
            {
                dialogueIndicator.gameObject.SetActive(true);   
            }
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("in yarn trigger");
            
            if (other.gameObject == fighter) //change to other.gameobject.name?
            {
                inYarnTrigger = true;
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                {
                    dialogueIndicator.gameObject.SetActive(true);
                }
                else if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
                {
                    dialogueIndicator.gameObject.SetActive(false);
                }
            }

            else if (other.gameObject == diviner)
            {
                inYarnTrigger = true;
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                {
                    dialogueIndicator.gameObject.SetActive(true);
                }
                else if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
                {
                    dialogueIndicator.gameObject.SetActive(false);
                }
   
            }
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        /*
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            FindObjectOfType<DialogueRunner>().Stop();
            FindObjectOfType<DialogueRunner>().startNode = nodeToCall;
        }
        */
        dialogueIndicator.gameObject.SetActive(false);
        inYarnTrigger = false;
    }
}
