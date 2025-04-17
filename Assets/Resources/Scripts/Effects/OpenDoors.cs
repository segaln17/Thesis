using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class OpenDoors : MonoBehaviour
{
    public Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand ("openDoors")]
    public void DoorsOpen()
    {
        doorAnim.SetBool("Open", true);
    }
}
