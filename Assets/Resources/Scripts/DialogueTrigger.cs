using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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
    
   // public bool isNearDialogue = false;
    
    //the gameobject with the collider (although this script is on the collider currently)
    public GameObject dialogueTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        //we do not want to see the text box until we go into the collider
        textBox.gameObject.SetActive(false);
        dialogueCoroutine = DialoguePlay();
        dialogueIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //setting the sprites to the component in the scriptable objects
    public void RenderDialogue(SpriteTextScriptableObjects spriteText)
    {
        textline.text = text1.writtenText;

    }

    private void OnTriggerEnter(Collider other)
    {
        //IF SECOND PERSON:
        if (gameObject.CompareTag("2ndPOV"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                dialogueIndicator.gameObject.SetActive(false);
                StopCoroutine(dialogueCoroutine);
                StartCoroutine(DialoguePlay());
            }
            {
                
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("in collider");
        //IF NOT SECOND PERSON:
        if (gameObject.tag != "2ndPOV")
        {
            if (other.gameObject.tag == "Player")
            {
                dialogueIndicator.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialogueIndicator.gameObject.SetActive(false);
                    //TODO: call the OnContinue from the LineView script basically
                    StopCoroutine(dialogueCoroutine);
                    StartCoroutine(DialoguePlay());
                }
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
        }
    }
}
