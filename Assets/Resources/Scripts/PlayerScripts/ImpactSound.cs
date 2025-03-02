using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioSource impactSound;
    public float impactMag = 1f;
    bool canPlayJumpLandingSound = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("oncollision");
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Oncollisionground");
            if (collision.relativeVelocity.magnitude > impactMag)
            {
                Debug.Log("should play");
                canPlayJumpLandingSound = true;
                if(!impactSound.isPlaying && canPlayJumpLandingSound == true)
                {
                    canPlayJumpLandingSound = false;
                    impactSound.Play();
                }
                
            }
        }


       
        
    }
}
