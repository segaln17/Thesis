using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Cinemachine;

public class HuskTreeCamSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera cameraToCutTo;
    public CinemachineVirtualCamera originalCamera;

    public GameObject huskCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [YarnCommand("cutToHuskCamera")]
    public void CutToCamera()
    {
        huskCamera.SetActive(true);
        cameraToCutTo.Priority = 12;
        originalCamera.Priority = 1;
    }
    
    [YarnCommand("cutBackFromHuskCamera")]
    public void CutBackCamera()
    {
        originalCamera.Priority = 12;
        cameraToCutTo.Priority = 1;
        huskCamera.SetActive(false);
    }
}
