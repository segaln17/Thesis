using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [Header("Player")] 
    Rigidbody rb;
    public float force = 5.0f;
    private Vector3 movementDirection;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * force);
        }
        
    }
}
