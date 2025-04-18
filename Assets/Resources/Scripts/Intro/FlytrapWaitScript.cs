using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using Cinemachine;

public class FlytrapWaitScript : MonoBehaviour
{
    public Button waitButton1;
    public Button waitButton2;
    public Button waitButtonFinal;

    public GameObject buttonCanvas;
    
    public IntroCutsceneAnimScript introCutsceneScript;
    
    //yarn stuff:
    private string nodeToCall;
    
    //cameras:
    public CinemachineVirtualCamera waitCam01;
    public CinemachineVirtualCamera waitCam02;
    public CinemachineVirtualCamera waitCam03;
    // Start is called before the first frame update
    void Start()
    {
        waitButton2.gameObject.SetActive(false);
        waitButtonFinal.gameObject.SetActive(false);
        waitCam02.Priority = 0;
        waitCam03.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstWaiting()
    {
        waitButton1.gameObject.SetActive(false);
        nodeToCall = "FlytrapWait1";
        StartCoroutine("Waiting");
        waitCam02.Priority = 12;
        waitCam01.Priority = 0;
        waitButton2.gameObject.SetActive(true);
    }

    public void SecondWaiting()
    {
        StopCoroutine("Waiting");
        waitButton2.gameObject.SetActive(false);
        nodeToCall = "FlytrapWait2";
        StartCoroutine("Waiting");
        waitCam03.Priority = 12;
        waitCam02.Priority = 0;
        waitButtonFinal.gameObject.SetActive(true);
    }

    IEnumerator Waiting()
    {
        buttonCanvas.gameObject.SetActive(false);
        //effects go here
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
        {
            FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
        }
        yield return new WaitForSeconds(5f);
        buttonCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
}
