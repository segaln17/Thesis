using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryActivation : MonoBehaviour
{

    public GameObject memoryAppear;
    public MemoryManager memoryManager;

    public MemoryCardChoose memoryCardChoose;
    
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
        if (GameManager.Instance.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                memoryManager.inMemoryGame = true;
                memoryAppear.SetActive(true);
                /*
                if (gameObject.CompareTag("Archaeologist"))
                {
                    memoryCardChoose.existingText01.text = memoryCardChoose.archaeFragment01;
                    memoryCardChoose.existingText02.text = memoryCardChoose.archaeFragment02;
                }
            
                else if (gameObject.CompareTag("Dreamer"))
                {
                    memoryCardChoose.existingText01.text = memoryCardChoose.dreamerFragment01;
                    memoryCardChoose.existingText02.text = memoryCardChoose.dreamerFragment02;
                }
                */
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
        if (GameManager.Instance.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                memoryAppear.SetActive(false);
                memoryManager.inMemoryGame = false;
            }
        }

    }
}
