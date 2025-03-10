using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class RookeryActivate : MonoBehaviour
{
    public PaintingSceneManager paintSceneManager;
    
    public CinemachineVirtualCamera rookeryCam;
    public CinemachineVirtualCamera firstPerson;
    public CinemachineVirtualCamera firstPersonDiviner;

    public GameObject Player;
    public GameObject PlayerDiviner;

    public GameObject CyanoManager;

    public Button cyanoonbutton;
    // Start is called before the first frame update
    void Start()
    {
        cyanoonbutton.gameObject.SetActive(false);
        CyanoManager.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Phoebe"))
        {
            cyanoonbutton.gameObject.SetActive(true); 
        }
        
    }

    private void OnTriggerExit(Collider other)
    { 
        cyanoonbutton.gameObject.SetActive(false); 
    }

    public void GotoCyanotype()
    {
        rookeryCam.Priority = 12;
        firstPerson.Priority = 1;
        CyanoManager.SetActive(true);
        //.GetComponent<PaintingSceneManager>().state = PaintingSceneManager.paintingState.newsheet;
        Player.SetActive(false);
        cyanoonbutton.gameObject.SetActive(false);
        //firstPersonDiviner.gameObject.SetActive(true);
        paintSceneManager.state = PaintingSceneManager.paintingState.newsheet;
    }
}
