using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureShriekScript : MonoBehaviour
{
    public AudioSource creatureNoiseSource;

    public AudioClip creatureShriek;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                creatureNoiseSource.PlayOneShot(creatureShriek);
            }
        }
    }
}
