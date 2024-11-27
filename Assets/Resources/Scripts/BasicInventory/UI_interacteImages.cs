using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_interacteImages : MonoBehaviour
{
    public InventoryManager inventoryManager;

    [Header("Interactables Images")]
    [SerializeField] private RawImage[] interactableImages;
    [SerializeField] private string[] itemNames;

    //public RawImage song01;
    public string song01;

    private void Start()
    {
        inventoryManager.AddItem(song01);
    }

    void Update()
    {
        for (int i = 0; i < interactableImages.Length; i++)
        {
            UpdateInventoryImage(interactableImages[i], itemNames[i]);
        }
    }

    private void UpdateInventoryImage(RawImage InventoryImage, string itemName)
    {
        bool hasItem = inventoryManager.HasItem(itemName);
        InventoryImage.enabled = hasItem;
    }
}
