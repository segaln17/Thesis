using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSceneManager : MonoBehaviour
{
    [Header("Manager Objects")]
    public GameObject mousePainter;
    public GameObject paperFake;
    public GameObject paperReal;
    public GameObject sheetNest;
    public GameObject paperPlacement;

    [Header("Placeable Objects")] 
    public GameObject[] placeableObjects;
    public GameObject[] stampedObjects;
    //public GameObject[] stamps;
    //private int placeableObjectsIndex;
    //private int stampedObjectsIndex;
    
    public paintingState state;
    public enum paintingState
    {
        newsheet,
        painting,
        placing
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
            //Debug.Log("newsheet");
        }
        if (state == paintingState.painting)
        {
            //Debug.Log("painting");
        }
        if (state == paintingState.placing)
        {
            if (Input.GetKeyUp(KeyCode.E))
                
            {
                placing();
            }
            
        }
    }

    public void newSheet()
    {
        state = paintingState.newsheet;
    }
    public void painting()
    {
        state = paintingState.painting;
    }

    public void placing()
    {
        foreach (GameObject placeable in placeableObjects)
        {  foreach (GameObject stamp in stampedObjects)
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

            placeable.gameObject.SetActive(false);
        }
        
    }
}
