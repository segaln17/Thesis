using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    //the textBox UI element
    public GameObject textBox;
    
    //the image rendering the text sprite
    public Image textImage;
    
    //the first scriptable object referenced:
    public SpriteTextScriptableObjects text1;
    //the sprite associated with it:
    public Sprite text1Sprite;
    
    //second scriptable object referenced:
    public SpriteTextScriptableObjects text2;
    //sprite associated with it:
    public Sprite text2Sprite;

    public SpriteTextScriptableObjects text3;

    public TextMeshProUGUI textline;
    
   
    //TODO: implement string text assignment from scriptable objects
    
    //DEFUNCT THINGS
    //public Transform textUITransform;
    //public Sprite testBox;
    
    //the gameobject with the collider (although this script is on the collider currently)
    public GameObject dialogueTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        //we do not want to see the text box until we go into the collider
        textBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //setting the sprites to the component in the scriptable objects
    public void RenderDialogue(SpriteTextScriptableObjects spriteText)
    {
        //set the text1Sprite to be the sprite asset in the scriptable object
        //text1Sprite = text1.textLine;
        //do the same for the other one
        //text2Sprite = text2.textLine;
        textline.text = text1.writtenText;

    }
    
    private void OnTriggerEnter(Collider other)
    {
        //text box on
        textBox.gameObject.SetActive(true);
        //set the sprites using a scriptable object as the parameter
        RenderDialogue(text1);
        //coroutine to play and display the dialogue
        StartCoroutine(DialoguePlay());
    }

    IEnumerator DialoguePlay()
    {
        //first sprite displayed
        //textImage.sprite = text1Sprite;
        yield return new WaitForSeconds(3f);
        //second sprite displayed
        //textImage.sprite = text2Sprite;
        textline.text = text2.writtenText;
        yield return new WaitForSeconds(3f);
        if (text3.writtenText == "null")
        {
            textBox.gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
        }
        else
        {
            textline.text = text3.writtenText;
            yield return new WaitForSeconds(3f);
        }
        //we are done with the dialogue now so textBox goes away
        textBox.gameObject.SetActive(false);
    }
}
