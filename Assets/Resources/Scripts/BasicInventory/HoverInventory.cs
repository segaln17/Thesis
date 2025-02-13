using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image inventoryImage;

    public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI titleText;

    public Sprite thisImage;

    public string thisText;
    public string thisTitle;

    public GameObject textPanel;

    private bool mouseOver = false;

    public GameObject inventoryPanel;
   
    // Start is called before the first frame update
    void Start()
    {
        inventoryImage.gameObject.SetActive(false);
        inventoryText.gameObject.SetActive(false);
        textPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOver)
        {
            Debug.Log("looking");
        }

        if (inventoryPanel.activeInHierarchy == false)
        {
            inventoryImage.gameObject.SetActive(false);
            inventoryText.gameObject.SetActive(false);
            textPanel.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        Debug.Log("lookin");
        //set the inventory image to be this one
        inventoryText.text = thisText;
        titleText.text = thisTitle;
        inventoryImage.sprite = thisImage;
        textPanel.SetActive(true);
        inventoryText.gameObject.SetActive(true);
        inventoryImage.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        Debug.Log("leaving");
        inventoryImage.gameObject.SetActive(false);
        textPanel.SetActive(false);
        inventoryText.gameObject.SetActive(false);
    }
   
}
