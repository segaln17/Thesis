using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoebeLeftHand : MonoBehaviour
{
    public GameManager gameManager;
    
    public GameObject leftHand;

    public bool leftHandActive;

    //public Animator leftHandAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentPOV == GameManager.CharacterPOV.Fighter && Input.GetKeyDown(KeyCode.Q))
        {
            leftHandActive = !leftHandActive;
        }

        if (leftHandActive)
        {
            leftHand.SetActive(true);
            //animations go here
        }

        else
        {
            leftHand.SetActive(false);
            //animations go here
        }
    }
}
