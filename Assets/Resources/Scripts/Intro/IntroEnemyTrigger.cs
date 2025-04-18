using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class IntroEnemyTrigger : MonoBehaviour
{
    public GameObject thisGameObject;
    public GameObject player;
    public GameObject enemyManager;
    public Collider thisCollider;
    public GameObject shatter;
    public GameObject phoebebattlesprite;
    public CinemachineVirtualCamera firstperson;
    public GameObject sprite;
    public AudioSource battleSound;
    
    // Start is called before the first frame update
    private void Start()
    {
        enemyManager.GetComponent<IntroCutsceneAnimScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            thisCollider.enabled = false;
            
            if (thisGameObject.tag == "flytrap")
            {
                shatter.SetActive(true);
                sprite.SetActive(false);
                firstperson.Priority = 12;
                phoebebattlesprite.SetActive(true);
                player.GetComponent<CutsceneController>().enabled = false;
                battleSound.Play();
                //player.GetComponent<SimpleController>().enabled = true;
                enemyManager.GetComponent<IntroCutsceneAnimScript>().FlyTrapTrigger();
                
            }
           
        }
    }
}
