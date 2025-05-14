using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenHandActiveRight : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject rightHand;
    public bool rightHandActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentPOV == GameManager.CharacterPOV.Diviner && Input.GetKeyDown(KeyCode.E))
        {
            rightHandActive = !rightHandActive;
        }

        if (rightHandActive)
        {
            rightHand.SetActive(true);
            //animations go here
        }

        else
        {
            rightHand.SetActive(false);
            //animations go here
        }
    }
}
