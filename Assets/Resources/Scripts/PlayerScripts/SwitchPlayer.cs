using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchPlayer : MonoBehaviour
{
    //public static CameraSwitch cameraController;
    //public GameObject camManager;
    
    public CinemachineVirtualCamera firstPerson;
    public CinemachineVirtualCamera thirdPerson;

    public bool firstPersonPOVOn = true;
    
    public CinemachineVirtualCamera firstPersonFighter;
    public CinemachineVirtualCamera thirdPersonFighter;
    public CinemachineVirtualCamera firstPersonDiviner;
    public CinemachineVirtualCamera thirdPersonDiviner;

    public GameObject Diviner;
    public GameObject Fighter;
    public GameObject FighterSprite01;
    public GameObject FighterFeetSprite;

    public bool fighterOn;

    public bool divinerOn;

    public GameObject soundManager;
    // Start is called before the first frame update
    void Awake()
    {
        fighterOn = true;
        divinerOn = false;

        firstPerson = firstPersonFighter;
        thirdPerson = thirdPersonFighter;

        Fighter.GetComponent<SimpleController>().enabled = true;
        Diviner.GetComponent<SimpleController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // firstPersonPOVOn = !firstPersonPOVOn;

        if (fighterOn)
        {
            firstPerson = firstPersonFighter;
            thirdPerson = thirdPersonFighter;
            FighterCam();
            
        }else if (divinerOn)
        {
            firstPerson = firstPersonDiviner;
            thirdPerson = thirdPersonDiviner;
            DivinerCam();
        }

       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("No More Control of Third Person");
            //firstPersonPOVOn = !firstPersonPOVOn;
        }*/
        
        if (firstPersonPOVOn && fighterOn)
        {
            firstPersonFighter.Priority = 5;
            firstPersonDiviner.Priority = 1;
            thirdPersonFighter.Priority = 2;
            thirdPersonDiviner.Priority = 1;
            StartCoroutine(hideSprite());
        }
        else if(!firstPersonPOVOn && fighterOn)
        {
            StopCoroutine(hideSprite());
            FighterFeetSprite.SetActive(false);
            FighterSprite01.SetActive(true);
            thirdPersonFighter.Priority = 5;
            thirdPersonDiviner.Priority = 1;
            firstPersonFighter.Priority = 2;
            firstPersonDiviner.Priority = 1;
            
        }

        if (firstPersonPOVOn && divinerOn)
        {
            firstPersonDiviner.Priority = 5;
            firstPersonFighter.Priority = 1;
            thirdPersonDiviner.Priority = 2;
            thirdPersonFighter.Priority = 1;
        } else if (!firstPersonPOVOn && divinerOn)
        {
                
            thirdPersonDiviner.Priority = 5;
            thirdPersonFighter.Priority = 1;
            firstPersonDiviner.Priority = 2;
            firstPersonFighter.Priority = 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("im player");
            if (Input.GetKeyDown(KeyCode.R))
            {
                fighterOn = !fighterOn;
                divinerOn = !divinerOn;
            }
        }
    }
    
    void FighterCam()
    {   Fighter.GetComponent<SimpleController>().enabled = true;
        Diviner.GetComponent<SimpleController>().enabled = false;
        soundManager.SetActive(true);
        
        /*firstPersonFighter.Priority = 5;
        firstPersonDiviner.Priority = 1;
        thirdPersonFighter.Priority = 2;
        thirdPersonDiviner.Priority = 1;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!firstPersonPOVOn)
            {
                firstPersonPOVOn = true;
            }
            else
            {
                firstPersonPOVOn = false;
                thirdPersonFighter.Priority = 5;
                thirdPersonDiviner.Priority = 1;
                firstPersonFighter.Priority = 2;
                firstPersonDiviner.Priority = 1;
            }
        }*/
    }

    void DivinerCam()
    {
        Diviner.GetComponent<SimpleController>().enabled = true;
        Fighter.GetComponent<SimpleController>().enabled = false;
        soundManager.SetActive(false);
        
        /*firstPersonDiviner.Priority = 5;
        firstPersonFighter.Priority = 1;
        thirdPersonDiviner.Priority = 2;
        thirdPersonFighter.Priority = 1;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!firstPersonPOVOn)
            {
                firstPersonPOVOn = true;
            }
            else
            {
                firstPersonPOVOn = false;
                thirdPersonDiviner.Priority = 5;
                thirdPersonFighter.Priority = 1;
                firstPersonDiviner.Priority = 2;
                firstPersonFighter.Priority = 1;
            }
        }*/
    }

    IEnumerator hideSprite()
    {
        yield return new WaitForSeconds(3.5f);
        FighterSprite01.SetActive(false);
        FighterFeetSprite.SetActive(true);
    }
}
