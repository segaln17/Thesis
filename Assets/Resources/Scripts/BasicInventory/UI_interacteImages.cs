using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class UI_interacteImages : MonoBehaviour
{
    public InventoryManager inventoryManager;

    [Header("Interactables Images")]
    [SerializeField] private RawImage[] interactableImages;
    [SerializeField] private string[] itemNames;

    //public RawImage song01;
    public string song01;
    
    //for Song of Beasts cutscene:
    public string song02;

    //for Garden cutscene
    public string musicBoxBase;
    
    //for Spine cutscene
    public string musicBoxFigure;
    
    //for Fen
    public string Trowel;
    
    //controls:
    public string Controls;

    private void Start()
    {
        inventoryManager.AddItem(song01);
        inventoryManager.AddItem(Controls);
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
    
    [YarnCommand("getSongofBeasts")]
    public void GetSongOfBeasts()
    {
        if (inventoryManager.gameObject.CompareTag("Phoebe"))
        {
            inventoryManager.AddItem(song02);
            Debug.Log("got song of beasts");
        }
       
    }

    [YarnCommand("getMusicBoxBase")]
    public void GetMusicBoxBase()
    {
        if (inventoryManager.gameObject.CompareTag("Phoebe"))
        {
            inventoryManager.AddItem(musicBoxBase);
            Debug.Log("got music box base");
        }
      
    }
    
    [YarnCommand("getMusicBoxFigure")]
    public void GetMusicBoxFigure()
    {
        if (inventoryManager.gameObject.CompareTag("Phoebe"))
        {
            inventoryManager.AddItem(musicBoxFigure);
            Debug.Log("got music box figure");
        }
        
    }

    [YarnCommand("getTrowel")]
    public void GetTrowel()
    {
        if (inventoryManager.gameObject.CompareTag("Fen"))
        {
            inventoryManager.AddItem(Trowel);
        }
        
    }
}
