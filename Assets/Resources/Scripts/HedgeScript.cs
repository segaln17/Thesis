using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgeScript : MonoBehaviour
{
    public Queue<string> noteQueue = new Queue<string>();
    
    //string that's the goal string
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //load in goal phrase
    //if keys are pressed, load in the letters
    //compare queue to target phrase
    //if it's the same, play a sound maybe and do an animation of stuff parting
}
