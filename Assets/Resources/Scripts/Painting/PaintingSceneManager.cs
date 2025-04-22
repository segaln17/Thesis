using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class PaintingSceneManager : MonoBehaviour
{
    //public DialogueViewBase cloudView;
    
    public RookeryActivate rookeryControls;
    public YarnDialogueTrigger yarnDialogueTrigger;
    public SimpleController divinerController;
    public DialogueTrigger outsideRookeryTrigger;
    
    public PaperPlacement paperPlacementScript;
    public CyanobrushCollider cyanobrushCollider;
    [Header("Manager Objects")]
    public GameObject mousePainter;

    public SpriteMask paperMask;
    
    private string nodeToCall;
    //public GameObject cyanoBrush;
    //public GameObject paperFake;
    //public GameObject paperReal;
    public GameObject sheetNest;
    public GameObject paperPlacement;
    public CinemachineVirtualCamera rookeryCam;
    public CinemachineVirtualCamera rookeryCam02;
    public GameObject flashObject;
    public GameObject makecyanotypeObj;

    [Header("UI")] 
    //public Button placingButton;
    public Button printButton;
    public Button wallPlacementButton;
   // public Button resetButton;
    public Button endButton;

    [Header("Placeable Objects")] 
    public GameObject[] placeableObjects;
    public GameObject[] stampedObjects;
    public Transform[] originalPos;

    [Header("Bools")] 
    public bool paintbrushActive = false;
    
    public bool paintHelpPlayed = false;
    public bool placeHelpPlayed = false;
    public bool printHelpPlayed = false;
    public bool hangHelpPlayed = false;
    public bool leaveHelpPlayed = false;
    //public AudioSource rookAud;
    //public AudioClip paintingS;

    [Header("DialogueRunners")] 
    public GameObject overworldDialogue;

    public GameObject cloudDialogue;
    public GameObject advanceNormal;
    public GameObject advanceCloud;
    
    
    [Header("States")]
    public paintingState state;
    public enum paintingState
    {
        newsheet, //get new sheet
        painting, //paint, turn on mousepainter when you click paintbrush and have it follow
        placing, //triggered when you put paintbrush back within collider
        printing, //button that stamps it
        wallPlacing, //put it on the wall, permanently turns off the wall collider it's on
        reset, //isDone is false, go into newsheet
        leave
    }
    
    
    void Start()
    {
        //placeableObjectsIndex = placeableObjects.Length;
        //stampedObjectsIndex = stampedObjects.Length;
        //placingButton.gameObject.SetActive(false);
        printButton.gameObject.SetActive(false);
        wallPlacementButton.gameObject.SetActive(false);
        //resetButton.gameObject.SetActive(false);
        endButton.gameObject.SetActive(false);
        cloudDialogue.SetActive(false);
        advanceCloud.SetActive(false);
        
    }

    
    void Update()
    {
        
        
        if (state == paintingState.newsheet)
        {
            
            newSheet();
            if (paintbrushActive)
            {
                if (cyanobrushCollider.iscarrying == false)
                {
                    //printButton.gameObject.SetActive(true);
                    mousePainter.SetActive(false);
                    state = paintingState.placing;
                    //placingButton.gameObject.SetActive(true);

                }
            }
        }
        if (state == paintingState.painting)
        {

            painting();
            if (paintHelpPlayed == false)
            {
                nodeToCall = "Painting";
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                {
                    FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
                    paintHelpPlayed = true;
                }
            }
            
            if (paintbrushActive)
            {
                if (cyanobrushCollider.iscarrying == false)
                {
                    //printButton.gameObject.SetActive(true);
                    mousePainter.SetActive(false);
                    //cyanobrushCollider.GetComponent<CyanobrushCollider>().enabled = false;
                    state = paintingState.placing;
                    //placingButton.gameObject.SetActive(true);
             
                }
            }
        }
        if (state == paintingState.placing)
        {
            if (placeHelpPlayed == false)
            {
                nodeToCall = "Placing";
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                {
                    FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
                }

                placeHelpPlayed = true;
            }

        }

        if (state == paintingState.printing)
        {
            
            printButton.gameObject.SetActive(false);
            //wallPlacementButton.gameObject.SetActive(true);
        }

        if (state == paintingState.wallPlacing)
        {
            if (hangHelpPlayed == false)
            {
                nodeToCall = "HangingUp";
                if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                {
                    FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
                }

                hangHelpPlayed = true;
            }
           
            //wallPlacing();//camera changes to wall, click n drag script is back on, lerp to a collider on the wall then reset once lerped?
    
        }

        if (state == paintingState.reset)
        {
            reset();
            
        }

        if (state == paintingState.leave)
        {
            //Leave();
           
            endButton.gameObject.SetActive(true);
            //resetButton.gameObject.SetActive(false);
            
        }
    }

    public void newSheet()
    {
        state = paintingState.newsheet;
        rookeryCam02.Priority = 1;
        rookeryCam.Priority = 12;
        makecyanotypeObj.GetComponent<SphereCollider>().enabled = false;
        //cyanoBrush.GetComponent<BoxCollider>().enabled = true;
        if (paintbrushActive)
        {
            state = paintingState.painting;
        }
    }
    
    public void painting()
    {
        state = paintingState.painting;
        mousePainter.SetActive(true);
        
    }

    [YarnCommand ("placing")]
    public void prepPlacing()
    {
        mousePainter.SetActive(false);
        state = paintingState.placing;
    }
    
    [YarnCommand ("printing")]
    public void placing()
    {
        flashObject.SetActive(true);
        //printButton.gameObject.SetActive(false);
       // wallPlacementButton.gameObject.SetActive(true);
        foreach (GameObject placeable in placeableObjects)
        { 
            foreach (GameObject stamp in stampedObjects)
            {
                if (stamp.tag == placeable.tag)
                {
                    GameObject obj = Instantiate(stamp, placeable.transform.position, placeable.transform.rotation);
                    obj.transform.parent = sheetNest.transform;
                }
            }
            
            //make them roll away or return to original spots:

        }

        state = paintingState.printing;
        StartCoroutine(wallPlacingTrigger());
        //wallPlacementButton.gameObject.SetActive(true);
        Debug.Log("starting wall coroutine");
        
    }

    public void printing()
    {
        

        foreach (GameObject placedObj in placeableObjects)
        {
            foreach (Transform origPos in originalPos)
            {
                if (placedObj.tag == origPos.tag)
                {
                    placedObj.transform.position = origPos.transform.position; 
                }
                
            }
        }
       
    }

    [YarnCommand ("wallPlacing")]
    public void wallPlacing()
    {
        //state = paintingState.wallPlacing;
        Debug.Log("wallplacing");
        rookeryCam.Priority = 1;
        rookeryCam02.Priority = 12;

        if (paperPlacementScript.isRotated == false)
        {
            paperPlacementScript.turnOnClickandDrag();
            Debug.Log("turn on click and drag");
        }
        if(paperPlacementScript.isRotated == true)
        {
            state = paintingState.leave;
        }
        
        
        //call reset whenever it's done
    }

    public void reset()
    {
        Debug.Log("resetting");
        paperPlacementScript.isDone = false;
        paperPlacementScript.isRotated = false;
        paperPlacementScript.sheet01 = false;
        paperPlacement.GetComponent<Collider>().enabled = true;
        paintbrushActive = false;



    paintHelpPlayed = false;
    placeHelpPlayed = false;
    printHelpPlayed = false;
    leaveHelpPlayed = false;
    hangHelpPlayed = false;
        
        state = paintingState.newsheet;
    }

    [YarnCommand ("leave")]
    public void Leave()
    {

        //state = paintingState.leave;
        if (leaveHelpPlayed == false)
        {
            nodeToCall = "Leaving";
            if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
            {
                FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
            }

            leaveHelpPlayed = true;
        }
        rookeryCam.Priority = 1;
        rookeryCam02.Priority = 1;
        rookeryControls.firstPerson.Priority = 12;
        outsideRookeryTrigger.gameObject.SetActive(true);
        paperPlacementScript.isDone = false;
        paperPlacementScript.isRotated = false;
        paperPlacementScript.sheet01 = false;
        paperPlacement.GetComponent<Collider>().enabled = true;
        paintbrushActive = false;
        endButton.gameObject.SetActive(false);
        //resetButton.gameObject.SetActive(false);
        //placingButton.gameObject.SetActive(false);
        printButton.gameObject.SetActive(false);
        //wallPlacementButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
        rookeryControls.Player.SetActive(true);
        makecyanotypeObj.GetComponent<SphereCollider>().enabled = true;
        paintHelpPlayed = false;
        placeHelpPlayed = false;
        printHelpPlayed = false;
        leaveHelpPlayed = false;
        hangHelpPlayed = false;

    }

    [YarnCommand("printReady")]
    public void printAppear()
    {
        printButton.gameObject.SetActive(true);
    }

  
    IEnumerator wallPlacingTrigger()
    {
        yield return new WaitForSeconds(2f);
        state = paintingState.wallPlacing;
        StopCoroutine(wallPlacingTrigger());

    }
    

}
