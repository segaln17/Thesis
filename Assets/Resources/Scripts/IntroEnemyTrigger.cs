using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEnemyTrigger : MonoBehaviour
{
    public GameObject thisGameObject;
    public GameObject enemyManager;
    public Collider thisCollider;
    
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
                enemyManager.GetComponent<IntroCutsceneAnimScript>().FlyTrapTrigger();
            }
            else if (thisGameObject.tag == "husk")
            {
                enemyManager.GetComponent<IntroCutsceneAnimScript>().HuskTrigger();
            }
        }
    }
}
