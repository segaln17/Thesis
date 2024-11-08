using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [Header("Player")] 
    Rigidbody rb;

    public float force = 5.0f;
    public float maxVelocity = 2f;
    private Vector3 movementDirection;
    public Animator playerAnim;
    public bool isWalking;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isWalking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward.normalized * force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            
            rb.AddForce(Vector3.left.normalized * force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right.normalized * force);
        }
        

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back.normalized * force);
        }

        if (Input.GetKey((KeyCode.A)) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
            Vector3 zeroVelocity = new Vector3(0, rb.velocity.y, 0);
            rb.velocity = zeroVelocity;
        }

        if (isWalking)
        {
            playerAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
        }
        
        if( rb.velocity.sqrMagnitude > maxVelocity )
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rb.velocity *= 0.99f;
        }
        
        
    }
}
