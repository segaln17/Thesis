using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera firstPerson;

    public CinemachineVirtualCamera thirdPerson;

    public static CameraSwitch cameraState;

    public bool firstPersonPOVOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // firstPersonPOVOn = !firstPersonPOVOn;
            
            if (!firstPersonPOVOn)
            {
                firstPerson.Priority = 2;
                thirdPerson.Priority = 1;
                firstPersonPOVOn = true;
            }
            else
            {
                firstPerson.Priority = 1;
                thirdPerson.Priority = 2;
                firstPersonPOVOn = false;
            }
            
        }
    }
}
