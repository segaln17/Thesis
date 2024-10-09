using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlowerPicking : MonoBehaviour
{
    
    //check tag
    //if player has a BigFlower, they can only have 1 other BigFlower or 2-3 SmallFlowers
    //add to inventory only if there's space
    //add to an existing list of gameobjects

    public List<GameObject> BigFlowerInventory = new List<GameObject>();
    public List<GameObject> SmallFlowerInventory = new List<GameObject>();

    public GameObject flowerText;
    public GameObject doneCollectingUI;
    
    // Start is called before the first frame update
    void Start()
    {
        doneCollectingUI.SetActive(false);
        flowerText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem()
    {
        /*
        if (gameObject.tag == "BigFlower") 
        {
            Debug.Log("thing is here");
            if (BigFlowerInventory.Count <= 2){
                BigFlowerInventory.Add(gameObject);
                Debug.Log(BigFlowerInventory);
            }
        }
    
        
        if (SmallFlowerInventory.Count <= 5)
        {
            if (gameObject.tag == "SmallFlower")
            {
                SmallFlowerInventory.Add(gameObject);
                Debug.Log(SmallFlowerInventory);
            }
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        Debug.Log(other);
        //AddItem();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BigFlower") 
        {
            Debug.Log("thing is here");
            if (BigFlowerInventory.Count <= 4){
                flowerText.SetActive(true);
                if (Input.GetMouseButton(0))
                {
                    BigFlowerInventory.Add(other.gameObject);
                    Debug.Log(BigFlowerInventory);
                    //changing to setactive.false so it doesn't get destroyed from the list:
                    other.gameObject.SetActive(false);
                    flowerText.SetActive(false);
                    //Destroy(other.gameObject);
                }
            }
        }
        
        if (SmallFlowerInventory.Count <= 6)
        {
            if (other.gameObject.tag == "SmallFlower")
            {
                flowerText.SetActive(true);
                if (Input.GetMouseButton(0))
                {
                    SmallFlowerInventory.Add(other.gameObject);
                    Debug.Log(SmallFlowerInventory);
                    //changing to setactive.false so it doesn't get destroyed from the list:
                    other.gameObject.SetActive(false);
                    flowerText.SetActive(false);
                    //Destroy(other.gameObject);
                }
            }
        }
            
        //show the done collecting UI
        if (BigFlowerInventory.Count >=4 || SmallFlowerInventory.Count >= 6)
        {
            doneCollectingUI.SetActive(true);
        }
    }

}
