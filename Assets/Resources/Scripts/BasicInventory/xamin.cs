using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xamin : MonoBehaviour , IExamining
{
    [SerializeField] GameObject object_clone;
    [SerializeField] InventoryManager inventoryManager;

    public string itemName;
    public void Examine()
    {
        if (inventoryManager.HasItem(itemName))
        {
            Debug.Log("I have the item");
            object_clone.SetActive(true);
            inventoryManager.RemoveItem(itemName);
            gameObject.layer = 0; //Default Layer
        }
        else
        {
            Debug.Log("I don't have the item");
        }      
    }

}
