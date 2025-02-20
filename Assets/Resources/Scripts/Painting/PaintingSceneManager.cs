using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class PaintingSceneManager : MonoBehaviour
{
    public RookeryActivate rookeryControls;
    public YarnDialogueTrigger yarnDialogueTrigger;
    public SimpleController divinerController;
    public DialogueTrigger outsideRookeryTrigger;
    
    public PaperPlacement paperPlacementScript;
    public CyanobrushCollider cyanobrushCollider;
    [Header("Manager Objects")]
    public GameObject mousePainter;

    public SpriteMask paperMask;
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
    public Button resetButton;
    public Button endButton;

    [Header("Placeable Objects")] 
    public GameObject[] placeableObjects;
    public GameObject[] stampedObjects;
    public Transform[] originalPos;

    [Header("Bools")] 
    public bool paintbrushActive = false;
    //public AudioSource rookAud;
    //public AudioClip paintingS;
    
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
        resetButton.gameObject.SetActive(false);
        endButton.gameObject.SetActive(false);

       /* for (int i = 0; i < placeableObjects.Length; i++)
        {
            var originalPoint = originalPos.Length > i ? originalPos[i] : originalPos[originalPos.Length - 1];
            originalPoint =
        }*/
        
    }

    
    void Update()
    {
        
        
        if (state == paintingState.newsheet)
        {
            resetButton.gameObject.SetActive(false);
            newSheet();
        }
        if (state == paintingState.painting)
        {
            //Debug.Log("painting");
            painting();
            if (paintbrushActive)
            {
                if (cyanobrushCollider.iscarrying == false)
                {
                    printButton.gameObject.SetActive(true);
                    mousePainter.SetActive(false);
                    //placingButton.gameObject.SetActive(true);
                    //MANUAL METHOD
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        state = paintingState.placing;
                        mousePainter.SetActive(false);
                    }
                }
            }
        }
        if (state == paintingState.placing)
        {
            //placingButton.gameObject.SetActive(false);
            printButton.gameObject.SetActive(true);
            mousePainter.SetActive(false);

        }

        if (state == paintingState.printing)
        {
            //printing();
            printButton.gameObject.SetActive(false);
            wallPlacementButton.gameObject.SetActive(true);
        }

        if (state == paintingState.wallPlacing)
        {
            wallPlacing();//camera changes to wall, click n drag script is back on, lerp to a collider on the wall then reset once lerped?
            resetButton.gameObject.SetActive(true);
            wallPlacementButton.gameObject.SetActive(false);
            endButton.gameObject.SetActive(true);
        }

        if (state == paintingState.reset)
        {
            //enterbutton.gameObject.SetActive(false);
            reset();
            
        }

        if (state == paintingState.leave)
        {
            Leave();
            endButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(false);
            
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

    public void prepPlacing()
    {
        mousePainter.SetActive(false);
        state = paintingState.placing;
    }
    
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

    public void wallPlacing()
    {
        state = paintingState.wallPlacing;
        rookeryCam.Priority = 1;
        rookeryCam02.Priority = 12;

        if (paperPlacementScript.isRotated == false)
        {
            paperPlacementScript.turnOnClickandDrag();
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
        state = paintingState.newsheet;
    }

    public void Leave()
    {
        //Debug.Log("leaving");
        state = paintingState.leave;
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
        resetButton.gameObject.SetActive(false);
        //placingButton.gameObject.SetActive(false);
        printButton.gameObject.SetActive(false);
        wallPlacementButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
        rookeryControls.Player.SetActive(true);
        makecyanotypeObj.GetComponent<SphereCollider>().enabled = true;

    }
    
    
}
