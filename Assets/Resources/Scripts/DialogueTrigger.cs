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

    public TextMeshProUGUI textline;
    
    private IEnumerator dialogueCoroutine;
    
   // public bool isNearDialogue = false;
    
    //the gameobject with the collider (although this script is on the collider currently)
    public GameObject dialogueTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        //we do not want to see the text box until we go into the collider
        textBox.gameObject.SetActive(false);
        dialogueCoroutine = DialoguePlay();
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
        StopCoroutine(dialogueCoroutine);
        StartCoroutine(DialoguePlay());

    }

    IEnumerator DialoguePlay()
    {
        
        while(true)
        {
            textBox.gameObject.SetActive(true);
            RenderDialogue(text1);
            yield return new WaitForSeconds(3f);
            textline.text = text2.writtenText;
            yield return new WaitForSeconds(3f);
            if (text3.writtenText == "null")
            {
                textBox.gameObject.SetActive(false);
                yield return new WaitForSeconds(3f);
                yield return null;
            }
            else
            {
                textline.text = text3.writtenText;
                yield return new WaitForSeconds(3f);
                textBox.gameObject.SetActive(false);
                yield return null;
            }
            yield break;
            //TODO: figure out how to break if leaving the collider in the middle
        }

    }
    
}
