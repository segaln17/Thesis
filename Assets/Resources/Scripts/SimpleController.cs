using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SimpleController : MonoBehaviour
{
    [Header("Player")]
    Rigidbody rb;
    public float force = 5.0f;
    private Vector3 movementDirection;

    //THE THINGS BELOW ARE AN ATTEMPT AT PARENTING CONTROLS TO WHERE THE CAMERA IS FACING
    //mouse sensitivity
    [Header("Camera Rotation")]
    public float sensX = 1f;
    public float sensY = 1f;

    public float xRotation;
    public float yRotation;

    public Transform orientation;
    
    public float mouseX;
    public float mouseY;
    
    [Header("Camera Switch")]
    public GameObject camManager;

    [Header("Movement Conditions")] 
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    public float groundDrag;
    
    [Header("Slope Conditions")] 
    public float maxSlopeAngle;
    public float slopeForce = 15f;
    public float slopeGravity = 80f;
    private RaycastHit slopeHit;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouse input for movement direction
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        
        //handle drag
        if (grounded) {
            rb.drag = groundDrag;
        }
        else {
            rb.drag = 0; 
        }
        SpeedControl();
        
        //switch player rotation lock
        if (camManager.GetComponent<SwitchPlayer>().firstPersonPOVOn)
        {
            FirstPerson();
        }
        if (camManager.GetComponent<SwitchPlayer>().firstPersonPOVOn == false)
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
        if (OnSlope())
        {
            movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            
            rb.AddForce(GetSlopeMoveDirection() * force * slopeForce, ForceMode.Force);

            if (rb.velocity.y > 0) {
                rb.AddForce(Vector3.down * slopeGravity, ForceMode.Force);
            }
        }
        //on ground
        else if (grounded)
        {
            movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            rb.AddForce(movementDirection.normalized * force * 10f, ForceMode.Force);
        }
        
        //turn gravity off while on slope
        rb.useGravity = !OnSlope();
  
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

    public bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 1f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        
        return false;
    }
    
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(movementDirection, slopeHit.normal).normalized;
    }

    private void SpeedControl()
    {
         // limiting speed on slope
        if (OnSlope())
        {
            if (rb.velocity.magnitude > force)
                rb.velocity = rb.velocity.normalized * force;
        }

        // limiting speed on ground or in air
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude > force)
            {
                Vector3 limitedVel = flatVel.normalized * force;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }
}
