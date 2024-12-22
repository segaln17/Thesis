using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SimpleController : MonoBehaviour
{
    [Header("Player")]
    Rigidbody rb;
    public float force = 5.0f;
    private Vector3 movementDirection;
    public bool isPlayerWalking;

    //THE THINGS BELOW ARE AN ATTEMPT AT PARENTING CONTROLS TO WHERE THE CAMERA IS FACING
    //mouse sensitivity
    //[Header("Camera Rotation")] 
   // public Transform camera;
    //public float sensX = 1f;
    //public float sensY = 1f;

    //public float xRotation;
    //public float yRotation;

    public Transform orientation;
    
   // public float mouseX;
    //public float mouseY;
    
    //[Header("Camera Switch")]
    //public GameObject camManager;

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
    
    //scene check
    //private Scene currentScene;
    //public GameObject feetSpriteFighter;
    

    /*[Header("Stair Conditions")] 
    [SerializeField] private GameObject stepRayUpper;
    [SerializeField] private GameObject stepRayLower;
    [SerializeField] private float stepHeight = 0.3f;
    [SerializeField] private float stepSmooth = 2f;*/

    private void Awake()
    {
        //currentScene = SceneManager.GetActiveScene();
        isPlayerWalking = false;
        //string sceneName = currentScene.name;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isPlayerWalking = false;
        //Cursor.visible = false;

        /*
        if (currentScene == SceneManager.GetSceneByName("GreyBoxing"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (currentScene == SceneManager.GetSceneByName("PaintingScene"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        */
        // stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //freeze player while dialogue is running
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == true)
        {
            return;
        }

        else
        { //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 1f, whatIsGround);
        
        //handle drag
        if (grounded) {
            rb.drag = groundDrag;
        }
        else {
            rb.drag = 1; 
        }
        SpeedControl();
        
        //rotate cam and orientation:
        //GetComponent<Camera>().rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //GetComponent<Camera>().position = orientation.position;        
        //orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        //transform.rotation = orientation.rotation;
        
        //controller using input to get directions
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        //Debug.Log(horizontalInput);
        if (horizontalInput > 0 || horizontalInput < 0 || verticalInput > 0 || verticalInput < 0)
        {
            isPlayerWalking = true;
        }
        else
        {
            isPlayerWalking = false;
        }

        //new attempt at movement:
        if (OnSlope())
        {
            movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            
            rb.AddForce(GetSlopeMoveDirection() * force * slopeForce * Time.deltaTime, ForceMode.Force);

            /*if (rb.velocity.y > 0) {
                rb.AddForce(Vector3.down * slopeGravity * Time.deltaTime, ForceMode.Force);
            }*/
            
            //Debug.Log("im on da slope");
        }
        //on ground
        else if (grounded)
        {
            movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            rb.AddForce(movementDirection.normalized * force * 10f * Time.deltaTime, ForceMode.Force);
            
            
            //Debug.Log("im on da ground");
        }
        if (rb.velocity.y > 0) {
            rb.AddForce(Vector3.down * slopeGravity * Time.deltaTime, ForceMode.Force);
        }
        //turn gravity off while on slope
        //rb.useGravity = !OnSlope();
       // stepClimb();
        }
        
  
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
