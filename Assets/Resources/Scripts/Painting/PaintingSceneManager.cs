using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaintingSceneManager : MonoBehaviour
{
    public PaperPlacement paperPlacementScript;
    public CyanobrushCollider cyanobrushCollider;
    [Header("Manager Objects")]
    public GameObject mousePainter;
    public GameObject cyanoBrush;
    public GameObject paperFake;
    public GameObject paperReal;
    public GameObject sheetNest;
    public GameObject paperPlacement;

    private Vector3 originalPos;

    [Header("Placeable Objects")] 
    public GameObject[] placeableObjects;
    public GameObject[] stampedObjects;
    //public GameObject[] stamps;
    //private int placeableObjectsIndex;
    //private int stampedObjectsIndex;

    public bool paintbrushActive = false;

    //public BoxCollider brushCollider;
    
    public paintingState state;
    public enum paintingState
    {
        newsheet, //get new sheet
        painting, //paint, turn on mousepainter when you click paintbrush and have it follow
        placing, //triggered when you put paintbrush back within collider
        printing, //button that stamps it
        wallPlacing, //put it on the wall, permanently turns off the wall collider it's on
        reset //isDone is false, go into newsheet
    }
    
    
    void Start()
    {
        //placeableObjectsIndex = placeableObjects.Length;
        //stampedObjectsIndex = stampedObjects.Length;
    }

    
    void Update()
    {
        
        
        if (state == paintingState.newsheet)
        {
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
            if (Input.GetKeyUp(KeyCode.E))

            {
                placing();
            }
            
        }

        if (state == paintingState.printing)
        {
            printing();
        }

        if (state == paintingState.wallPlacing)
        {
            //camera changes to wall, click n drag script is back on, lerp to a collider on the wall then reset once lerped?
        }

        if (state == paintingState.reset)
        {
            reset();
        }
    }

    public void newSheet()
    {
        state = paintingState.newsheet;
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
        foreach (GameObject originalspot in placeableObjects)
        {
            originalPos = originalspot.transform.position;
        }
    }

    public void placing()
    {
        foreach (GameObject placeable in placeableObjects)
        {
            foreach (GameObject stamp in stampedObjects)
            {
                if (stamp.tag == placeable.tag)
                {
                    GameObject obj = Instantiate(stamp, placeable.transform.position, placeable.transform.rotation);
                    obj.transform.parent = sheetNest.transform;
                    //stamp.tag = "Untagged";
                }
            }
            /*for (int p = 0; p < placeableObjectsIndex; p++)
            {
                    //setting transform.positions for the stamps based on the placeables
                    //GameObject go = Instantiate(selector, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;//p = s;
                    //stamps = new GameObject[stampedObjects.Length]; //makes sure they match length
                    for (int i = 0; i < stampedObjects.Length; i++)
                    {
                      
                        //stamps[i] = Instantiate(stampedObjects[i], placeableObjects[p].transform.position, placeableObjects[p].transform.rotation) as GameObject;
                        /*if (stamps[i].tag == placeableObjects[p].tag)
                        {
                            stampedObjectsIndex = i;
                            break;
                        }
                    }
            }*/

            //placeable.gameObject.SetActive(false);
            //make them roll away or return to original spots:

        }
        state = paintingState.printing;
        
    }

    public void printing()
    {
        foreach (GameObject placedObj in placeableObjects)
        {
            placedObj.gameObject.transform.position = originalPos;
        }
    }

    public void wallPlacing()
    {
        state = paintingState.wallPlacing;
        //call reset whenever it's done
    }

    public void reset()
    {
        Debug.Log("resetting");
        paperPlacementScript.isDone = false;
        state = paintingState.newsheet;
    }
    
}
