using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.iOS;

public class SimpleController : MonoBehaviour
{
    
    Rigidbody rb;
    public float force = 5.0f;
    public float rotationSpeed = 100f;

    //THE THINGS BELOW ARE AN ATTEMPT AT PARENTING CONTROLS TO WHERE THE CAMERA IS FACING
    //mouse sensitivity
    public float sensX = 1f;
    public float sensY = 1f;

    public float xRotation;
    public float yRotation;

    public Transform orientation;
    
    public float mouseX;

    public float mouseY;

    private CameraSwitch cameraController;
    private void Awake()
    {
        cameraController = GetComponent<CameraSwitch>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        if (cameraController.firstPersonPOVOn)
        {
            FirstPerson();
        }

        if (cameraController.firstPersonPOVOn == false)
        {
            ThirdPerson();
        }
        
        
        //rotate cam and orientation:
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        
        //controller using input to get directions
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //new attempt at movement:
        Vector3 movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        rb.AddForce(movementDirection.normalized * force * 2f, ForceMode.Force);



        /*
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();


        rb.AddForce(movementDirection * force);
        //transform.Translate(movementDirection * force * Time.deltaTime, Space.World);
        */

        /*
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

*/
    }

    public void FirstPerson()
    {
        //for first person controller, min and max control lookroom (min is up, max is down)
        //for a third person controller, we would just have to make the clamp values be 0, 0
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    public void ThirdPerson()
    {
        xRotation = Mathf.Clamp(xRotation, 0, 0);
    }
}
