using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class YarnIntroDialogueTrigger : MonoBehaviour
{
    public string nodeToCall;
    public GameObject fighter;
    //public GameObject diviner;
    //public GameObject cleric;

    public Collider dialogueCollider;
    
    public bool inYarnTrigger;

    public bool cutsceneRun = false;

    private InMemoryVariableStorage inMemoryVariableStorage;

    public TextMeshProUGUI dialogueIndicator;
    //public bool isFighter;
    //public bool isDiviner;

    // Start is called before the first frame update
    void Start()
    {
        dialogueIndicator.gameObject.SetActive(false);
        inYarnTrigger = false;
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
            inYarnTrigger = true;
            if (other.gameObject == fighter) //change to other.gameobject.name?
            {
                SetCharacterPOV(GameManager.CharacterPOV.Fighter);
                //dialogueIndicator.gameObject.SetActive(false);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogueIndicator.gameObject.SetActive(false);
        inYarnTrigger = false;
    }

    public void SetCharacterPOV(GameManager.CharacterPOV targetPOV)
    {
        GameManager.Instance.currentPOV = targetPOV;
        //inMemoryVariableStorage.SetValue("$charPOV", targetPOV.ToString());
        FindObjectOfType<InMemoryVariableStorage>().SetValue("$charPOV", targetPOV.ToString());
    }

    [YarnCommand("turnOffCollider")]
    public void TurnOffCollider()
    {
        gameObject.SetActive(false);
    }
}
