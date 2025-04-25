using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Cinemachine;

public class MoonCustomCommands : MonoBehaviour
{
    public CinemachineVirtualCamera moonCam;
    public CinemachineVirtualCamera currentCam;
    public Animator moonAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand ("helloMoon")]
    public void MoonHello()
    {
        currentCam.Priority = 1;
        moonCam.Priority = 12;
        moonAnim.SetBool("HelloMoon", true);
    }
}
