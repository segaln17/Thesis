using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PhoebetoFenGardenCutsceneManager : MonoBehaviour
{
    public DialogueTrigger outsideRookeryTrigger;
    public DialogueTrigger insideRookeryTrigger;
    
    public TimelineTest timelineScript;

    public SimpleController divinerController;

    public GameObject PlayerPhoebe;

    public RookeryActivate rookeryControls;
    public CinemachineVirtualCamera fenCam01;
    public CinemachineVirtualCamera fenCam02;
    public CinemachineVirtualCamera phoebecam01;
    public GameObject phoebefeet;
    public GameObject phoebecolorway;
    public bool isswitiching;
    public bool isswitched;

    public GameObject stableLight;

    public YarnDialogueTrigger yarnDialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isswitiching = false;
        isswitched = false;
        stableLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (outsideRookeryTrigger.dialoguePlayed)
        {
            StartCoroutine("WaitSwitchtoFen");
            stableLight.SetActive(true);
            outsideRookeryTrigger.dialoguePlayed = false;
        }

        /*if (!isswitiching && !isswitched)
        {
            StartCoroutine(PhoebeReveal());
        }*/
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isswitiching = true;
        }
       
    }

    IEnumerator PhoebeReveal()
    {
        yield return new WaitForSeconds(2f);
        rookeryControls.firstPerson.Priority = 1;
        phoebecam01.Priority = 12;
        phoebefeet.SetActive(false);
        phoebecolorway.SetActive(true);
        PlayerPhoebe.GetComponent<SimpleController>().enabled = false;
        isswitched = true;
        StopCoroutine(PhoebeReveal());

    }

    IEnumerator WaitSwitchtoFen()
    {
        Debug.Log("switching to Fen");
        yield return new WaitForSeconds(2f);
        outsideRookeryTrigger.GetComponent<Collider>().enabled = false;
        outsideRookeryTrigger.GetComponent<DialogueTrigger>().enabled = false;
        insideRookeryTrigger.GetComponent<DialogueTrigger>().enabled = false;
        PlayerPhoebe.GetComponent<SimpleController>().enabled = false;
        PlayerPhoebe.gameObject.SetActive(false);
        //switch camera to Fen
        phoebecam01.Priority = 0;
        rookeryControls.firstPerson.Priority = 1;
        fenCam01.Priority = 12;
        yield return new WaitForSeconds(4f);
        //zoom in to Fen
        fenCam02.Priority = 12;
        fenCam01.gameObject.SetActive(false);
        fenCam01.Priority = 1;
        //set charPOV to diviner
        yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Diviner);
        //turn on Fen controller
        divinerController.GetComponent<SimpleController>().enabled = true;
        yield return new WaitForSeconds(1f);
        //turn off Fen's dialogue trigger from tavern scene
        yarnDialogueTrigger.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //start the mini cutscene
        timelineScript.GoTimeline();
        StopCoroutine("WaitSwitchtoFen");
    }
}
