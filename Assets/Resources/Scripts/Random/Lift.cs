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

    //orientation phoebe, probably need to add fen and altea 2
    //public Vector3 movementDirection;
    public Transform orientation;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            phoebeRigidbody.AddForce(direction * strength);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            elevatorObj.SetActive(false);

            //float horizontalInput = Input.GetAxisRaw("Horizontal");
            //float verticalInput = Input.GetAxisRaw("Vertical");

            //movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            phoebeRigidbody.AddForce(orientation.forward * strength, ForceMode.Impulse);
        }
    }
}
