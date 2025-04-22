using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenColliderScript : MonoBehaviour
{
    
    //public GameObject elevatorArea;

    public SimpleController playerControllerPhoebe;
    public SimpleController playerControllerFen;
    public float waterForce = 1500f;
    public float groundForcePhoebe = 835f;
    public float groundForceFen = 775f;

    private void Start()
    {
        groundForceFen = playerControllerFen.force;
        groundForcePhoebe = playerControllerPhoebe.force;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        //this was in enter
        if (other.gameObject.CompareTag("Player")&& other.gameObject.name == "PlayerPhoebe")
        {
            playerControllerPhoebe.force = waterForce;
            //Debug.Log("entered collider");
        }
        else if (other.gameObject.CompareTag("Player")&& other.gameObject.name == "PlayerDiviner")
        {
            playerControllerFen.force = waterForce;
            //Debug.Log("entered collider");
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&& other.gameObject.name == "PlayerPhoebe")
        {
            playerControllerPhoebe.force = groundForcePhoebe;
            Debug.Log("left collider");
        }
        else if (other.gameObject.CompareTag("Player")&& other.gameObject.name == "PlayerDiviner")
        {
            playerControllerFen.force = groundForceFen;
            Debug.Log("leftCollider");
        }
    }
}
