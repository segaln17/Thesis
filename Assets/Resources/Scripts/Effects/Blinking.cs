using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public Animator blinker;

    //Bools 
    public bool timerActive = false;
    public bool isHolding = false;

    //Window Timer
    public float hitWindowTime = 0.0f;
    public float hitWindowCap = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hitWindowTime);

        if (timerActive)
        {
            hitWindowTime -= Time.deltaTime;

            //stopping the timer to limit the input
            /*if (hitWindowTime <= 0)
            {
                
            }*/
        
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            blinker.SetBool("blinking", true);
            StartWindowTimer();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            isHolding = true;

            if(hitWindowTime <= 0 && isHolding)
            {
                blinker.SetBool("blinkinghold", true);
                StopWindowTimer();
            }
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            blinker.SetBool("blinking", false);
            blinker.SetBool("blinkinghold", false);
            hitWindowTime = hitWindowCap;
            isHolding = false;
            timerActive = false;
        }


    }

    //------------//
    public void StartWindowTimer()
    {
        hitWindowTime = hitWindowCap;
        timerActive = true;
    }

    public void StopWindowTimer()
    {
        hitWindowTime = 0;
        //timerActive = false;
    }
    

}
