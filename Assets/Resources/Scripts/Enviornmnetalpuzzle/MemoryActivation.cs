using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryActivation : MonoBehaviour
{

    public GameObject memoryAppear;
    public MemoryManager memoryManager;

    public MemoryCardChoose memoryCardChoose;
    public bool colliderDreamerInside = false;
    public bool colliderArchaelogistInside = false;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                memoryManager.inMemoryGame = true;
                
                
                if (gameObject.CompareTag("Archaeologist"))
                {
                    colliderArchaelogistInside = true;
                    memoryManager.archaeButtons.SetActive(true);
                    memoryManager.dreamerButtons.SetActive(false);
                    /*memoryCardChoose.existingText01.text = memoryCardChoose.archaeFragment01;
                    memoryCardChoose.existingText02.text = memoryCardChoose.archaeFragment02;*/
                }
            
                else if (gameObject.CompareTag("Dreamer"))
                {
                    colliderDreamerInside = true;
                    memoryManager.dreamerButtons.SetActive(true);
                    memoryManager.archaeButtons.SetActive(false);
                    /*memoryCardChoose.existingText01.text = memoryCardChoose.dreamerFragment01;
                    memoryCardChoose.existingText02.text = memoryCardChoose.dreamerFragment02;*/
                }
                memoryAppear.SetActive(true);
            }
            else
            {
                memoryManager.inMemoryGame = false;
                memoryAppear.SetActive(false);
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                memoryAppear.SetActive(false);
                memoryManager.inMemoryGame = false;
                colliderArchaelogistInside = false;
                colliderDreamerInside = false;
            }
        }

    }
}
