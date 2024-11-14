using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class YarnDialogueTrigger : MonoBehaviour
{
    public string nodeToCall;
    public GameObject fighter;
    public GameObject diviner;
    //public GameObject cleric;

    private InMemoryVariableStorage inMemoryVariableStorage;

    public TextMeshProUGUI dialogueIndicator;
    public bool isFighter;
    public bool isDiviner;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueIndicator.gameObject.SetActive(true);   
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("in yarn trigger");
            //dialogueIndicator.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("talking");
                if (other.gameObject == fighter)
                {
                    isFighter = true;
                    isDiviner = false;
                    SetCharacterPOV(GameManager.CharacterPOV.Fighter);
                    dialogueIndicator.gameObject.SetActive(false);
                }

                else if (other.gameObject == diviner)
                {
                    isDiviner = true;
                    isFighter = false;
                    SetCharacterPOV(GameManager.CharacterPOV.Diviner);
                    dialogueIndicator.gameObject.SetActive(false);
                }

                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                {
                    FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
                }
                
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueIndicator.gameObject.SetActive(false);
    }

    public void SetCharacterPOV(GameManager.CharacterPOV targetPOV)
    {
        GameManager.Instance.currentPOV = targetPOV;
        //inMemoryVariableStorage.SetValue("$charPOV", targetPOV.ToString());
        FindObjectOfType<InMemoryVariableStorage>().SetValue("$charPOV", targetPOV.ToString());
    }
    /*
    public void ChangeCharacterPOV()
    {
        inMemoryVariableStorage.TryGetValue("$charPOV", out string charPOV);
        if (isFighter)
        {
            charPOV = "Fighter";
            inMemoryVariableStorage.SetValue("$charPOV", charPOV);
        }

        if (isDiviner)
        {
            charPOV = "Diviner";
            inMemoryVariableStorage.SetValue("$charPOV", charPOV);
        }
        //TODO: Implement Altea once we have a gameobject for her
    }
    */
    
}
