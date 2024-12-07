using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookeryInternalDialogueOff : MonoBehaviour
{
    public SphereCollider rookeryInternalCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        rookeryInternalCollider.enabled = false;
    }
}
