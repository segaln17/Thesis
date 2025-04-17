using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class UICustomCommands : MonoBehaviour
{
    //this will be for showing flashes of images
    public Image imageToShow;
    public CinemachineVirtualCamera cameraToCutTo;
    public CinemachineVirtualCamera originalCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        imageToShow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("showImage")]
    public void ShowImageSnapshot()
    {
        imageToShow.gameObject.SetActive(true);
    }

    [YarnCommand("hideImage")]
    public void HideImageSnapshot()
    {
        imageToShow.gameObject.SetActive(false);
    }

    [YarnCommand("cutToCamera")]
    public void CutToCamera()
    {
        cameraToCutTo.Priority = 12;
        originalCamera.Priority = 1;
    }
    
    [YarnCommand("cutBackCamera")]
    public void CutBackCamera()
    {
        originalCamera.Priority = 12;
        cameraToCutTo.Priority = 1;
    }
}
