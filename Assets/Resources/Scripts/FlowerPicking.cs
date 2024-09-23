using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPicking : MonoBehaviour
{
    
    //check tag
    //if player has a BigFlower, they can only have 1 other BigFlower or 2-3 SmallFlowers
    //add to inventory only if there's space
    //add to an existing list of gameobjects

    public List<GameObject> BigFlowerInventory = new List<GameObject>();
    public List<GameObject> SmallFlowerInventory = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (other.gameObject.tag == "BigFlower") 
        {
            Debug.Log("thing is here");
            if (BigFlowerInventory.Count <= 1){
                BigFlowerInventory.Add(other.gameObject);
                Debug.Log(BigFlowerInventory);
            }
        }
    
        
        if (SmallFlowerInventory.Count <= 2)
        {
            if (other.gameObject.tag == "SmallFlower")
            {
                SmallFlowerInventory.Add(other.gameObject);
                Debug.Log(SmallFlowerInventory);
            }
        }
    }
}
