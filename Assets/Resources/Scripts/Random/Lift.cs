using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public float strength;
    public Vector3 direction;
    public Rigidbody phoebeRigidbody;
    public Rigidbody fenRigidbody;

    public GameObject elevatorObj;
    public GameManager gameManager;

    //orientation phoebe, probably need to add fen and altea 2
    //public Vector3 movementDirection;
    public Transform phoebeorientation;
    public Transform fenorientation;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

            if(gameManager.currentPOV == GameManager.CharacterPOV.Fighter) 
        {
            phoebeRigidbody.AddForce(direction * strength);
        }
            else if (gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
            {
                fenRigidbody.AddForce(direction * strength);
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            elevatorObj.SetActive(false);

            if(gameManager.currentPOV == GameManager.CharacterPOV.Fighter)
            {
                phoebeRigidbody.AddForce(phoebeorientation.forward * strength, ForceMode.Impulse);
            }else if (gameManager.currentPOV == GameManager.CharacterPOV.Diviner)
            {
                fenRigidbody.AddForce(fenorientation.forward * strength, ForceMode.Impulse);
            }
            
        }
    }
}
