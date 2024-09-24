using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    
    Rigidbody rb;
    public float force = 5.0f;
    public float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //controller using input to get directions
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();


        rb.AddForce(movementDirection * force);
        //transform.Translate(movementDirection * force * Time.deltaTime, Space.World);


        //making sure that the player transform is smoothly following the direction of movement
        if (movementDirection != Vector3.zero)
        {
            //transform.forward =
                //movementDirection; //the players transform, will now face the direction that the new vector3 is facing but only if it isn't stationary

         
        Quaternion
            toRotation =
                Quaternion.LookRotation(movementDirection,
                    Vector3.up); //using quaternions to smooth out the rotation of directions. Type specifically to store rotations "looking" in a desired direction vector3.up is the y axis
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, toRotation,
                rotationSpeed * Time.deltaTime); //rotate towards is to rotate towards the desired direction

    }

    }
}
