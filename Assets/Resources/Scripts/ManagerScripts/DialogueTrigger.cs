using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    
    //the textBox UI element
    public GameObject textBox;
    
    
    //the first scriptable object referenced:
    public SpriteTextScriptableObjects text1;
    
    //second scriptable object referenced:
    public SpriteTextScriptableObjects text2;

    public SpriteTextScriptableObjects text3;

    public SpriteTextScriptableObjects text4;

    public TextMeshProUGUI textline;
    
    private IEnumerator dialogueCoroutine;

    public TextMeshProUGUI dialogueIndicator;

    public bool dialoguePlayed;
    
    public bool isNearDialogue = false;
    
    //the gameobject with the collider (although this script is on the collider currently)
    public GameObject dialogueTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        //we do not want to see the text box until we go into the collider
        textBox.gameObject.SetActive(false);
        dialogueCoroutine = DialoguePlay();
        dialogueIndicator.gameObject.SetActive(false);
        dialoguePlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearDialogue && gameObject.CompareTag("2ndPOV") || isNearDialogue && gameObject.CompareTag("2ndPOVObject"))
        {
            if (dialoguePlayed)
            {
                if (gameObject.name != "RookeryInternalBefore" || gameObject.name != "RookeryExternalAfter")
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        dialogueIndicator.gameObject.SetActive(false);
                        StopCoroutine(dialogueCoroutine);
                        StartCoroutine(DialoguePlay());
                    }
                }
                else if (gameObject.name == "RookeryExternalAfter")
                {
                    gameObject.GetComponent<DialogueTrigger>().enabled = false;
                }
                
            }
        }
    }

    //setting the sprites to the component in the scriptable objects
    public void RenderDialogue(SpriteTextScriptableObjects spriteText)
    {
        textline.text = text1.writtenText;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerPhoebe")
        {
            //IF SECOND PERSON:
            if (gameObject.CompareTag("2ndPOV"))
            {
                //if you're the player and you haven't seen this dialogue before
                if (other.gameObject.CompareTag("Player") && dialoguePlayed == false)
                {
                    //there should be no dialogue indicator and you're near the dialogue
                    dialogueIndicator.gameObject.SetActive(false);
                    isNearDialogue = true;
                
                    StopCoroutine(dialogueCoroutine);
                    StartCoroutine(DialoguePlay());
                }
                //if you have seen it before but want to see it again
                else if (other.gameObject.CompareTag("Player") && dialoguePlayed)
                {
                    //turn the dialogue indicator on and you're near dialogue
                    isNearDialogue = true;
                    dialogueIndicator.gameObject.SetActive(true);
                
                    //StopCoroutine(dialogueCoroutine);
                    //StartCoroutine(DialoguePlay());
                }
            }
        }
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("in collider");
        
        //IF SECOND PERSON BUT SPECIAL
        if (gameObject.tag == "2ndPOVObject")
        {
            if (other.gameObject.tag == "Player")
            {
                dialogueIndicator.gameObject.SetActive(true);
                isNearDialogue = true;
                
                //and set dialoguePlayed to true so you just have to trigger it
                dialoguePlayed = true;
                /*
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialogueIndicator.gameObject.SetActive(false);
                    StopCoroutine(dialogueCoroutine);
                    StartCoroutine(DialoguePlay());
                }
                */
            }
        }
        
        //}
        
    }

    IEnumerator DialoguePlay()
    {
        
        while(true)
        {
            //dialogueIndicator.gameObject.SetActive(false);
            textBox.gameObject.SetActive(true);
            RenderDialogue(text1);
            yield return new WaitForSeconds(4f);
            //textline.text = text2.writtenText;
            //IF THE SECOND TEXT LINE IS ALSO EMPTY:
            if (text2.writtenText == "null")
            {
                textBox.gameObject.SetActive(false);
                yield return new WaitForSeconds(4f);
                yield return null;
            }
            else
            {
                textline.text = text2.writtenText;
                yield return new WaitForSeconds(4f);
                if (text3.writtenText == "null")
                {
                    textBox.gameObject.SetActive(false);
                    yield return new WaitForSeconds(4f);
                    yield return null;
                }
                else
                {
                    textline.text = text3.writtenText;
                    yield return new WaitForSeconds(4f);
                    if (text4.writtenText == "null")
                    {
                        textBox.gameObject.SetActive(false);
                        yield return null;
                    }
                    else
                    {
                        textline.text = text4.writtenText;
                        yield return new WaitForSeconds(4f);
                        textBox.gameObject.SetActive(false);
                        yield return null;
                    }
                }
            }

            dialoguePlayed = true;
            //yield return new WaitForSeconds(3f);
            //NOTE: I put the if statement with the text3 code inside the else statement of the text2 code
            yield break;
            //TODO: figure out how to break if leaving the collider in the middle
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueIndicator.gameObject.SetActive(false);
            isNearDialogue = false;
        }
    }
}
