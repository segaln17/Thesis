using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MemoryGuidance : MonoBehaviour
{
    //Fen hand UI
    public GameObject fenHandUI;
    public GameObject memoryGuide;
    public TextMeshProUGUI memoryText;
    public string guidanceText;
    
    //nearby memory collider
    public GameObject memoryCollider;

    public bool inMemoryCollider = false;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fenHandUI.activeInHierarchy && inMemoryCollider)
        {
            memoryText.text = guidanceText;
            memoryGuide.SetActive(true);
        }
        else if (fenHandUI.activeInHierarchy == false)
        {
            memoryGuide.SetActive(false);
        }
        
        //if fen hand UI is active and you're within a collider:
        //text appears & animation plays
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            inMemoryCollider = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            inMemoryCollider = true;
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            inMemoryCollider = false;
        }
    }
}
