using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryActivation : MonoBehaviour
{

    public GameObject memoryAppear;
    public MemoryManager memoryManager;

    //public MemoryCardChoose memoryCardChoose;
    public bool colliderDreamerInside = false;
    public bool colliderArchaelogistInside = false;

    public GameManager gameManager;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            if(gameObject.CompareTag("Archaeologist") && other.gameObject.CompareTag("Player"))
            {
                memoryManager.inMemoryGame = true;
                Debug.Log("inside memory game");
                colliderArchaelogistInside = true;
                Debug.Log("inside arch");
                memoryAppear.SetActive(true);
            }
            else if (gameObject.CompareTag("Dreamer") && other.gameObject.CompareTag("Player"))
            {
                memoryManager.inMemoryGame = true;
                Debug.Log("inside memory game");
                colliderDreamerInside = true;
                Debug.Log("inside dreamer");
                memoryAppear.SetActive(true);

            }


        }
        else
        {
            memoryManager.inMemoryGame = false;
            memoryAppear.SetActive(false);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
        {
            if (gameObject.CompareTag("Archaeologist") && other.gameObject.CompareTag("Player"))
            {
                memoryManager.inMemoryGame = true;
                Debug.Log("inside memory game");
                colliderArchaelogistInside = true;
                Debug.Log("inside arch");
                memoryAppear.SetActive(true);
            }
            else if (gameObject.CompareTag("Dreamer") && other.gameObject.CompareTag("Player"))
            {
                memoryManager.inMemoryGame = true;
                Debug.Log("inside memory game");
                colliderDreamerInside = true;
                Debug.Log("inside dreamer");
                memoryAppear.SetActive(true);

            }



        }
        else
        {
            memoryManager.inMemoryGame = false;
            memoryAppear.SetActive(false);
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
