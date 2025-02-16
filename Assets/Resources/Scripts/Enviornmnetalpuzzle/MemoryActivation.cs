using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryActivation : MonoBehaviour
{

    public GameObject memoryAppear;
    public MemoryManager memoryManager;
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
        if (other.gameObject.CompareTag("Player"))
        {
            memoryManager.inMemoryGame = true;
            memoryAppear.SetActive(true);
        }
        else
        {
            memoryManager.inMemoryGame = false;
            memoryAppear.SetActive(false);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            memoryAppear.SetActive(false);
            memoryManager.inMemoryGame = false;
        }

    }
}
