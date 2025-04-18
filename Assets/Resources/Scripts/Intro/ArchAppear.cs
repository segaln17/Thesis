using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchAppear : MonoBehaviour
{
    public Animator archAnimator;

    public GameObject arch;

    public GameObject player;

    public Vector3 direction;
    public bool archActive;
    public Rigidbody rb;
    public float pullStrength;
    // Start is called before the first frame update
    void Start()
    {
        archActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (archActive == true)
        {
            rb.AddForce(direction * pullStrength);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            archAnimator.SetBool("Entered", true);
            archActive = true;
            //currentPos.position = Vector3.MoveTowards(currentPos.position, arch.transform.position, 30f);
        }
    }
}
