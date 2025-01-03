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

    public GameObject PlayerPhoebe;
    public GameObject PlayerFen;

    public CinemachineVirtualCamera fenCam01;
    public CinemachineVirtualCamera fenCam02;
    public CinemachineVirtualCamera phoebecamfirstPerson;
    public CinemachineVirtualCamera phoebecam01;
    public GameObject phoebefeet;
    public GameObject phoebecolorway;
    public GameObject fencolorway;
    public GameObject gardenYarnTrigger;
    public GameObject audioManager;

    public GameObject stableLight;

    public YarnDialogueTrigger yarnDialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
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



    }

    IEnumerator WaitSwitchtoFen()
    {
        Debug.Log("switching to Fen");
        yield return new WaitForSeconds(.5f);
        phoebecamfirstPerson.Priority = 1;
        phoebecam01.Priority = 12;
        Debug.Log("phoebethirdperson");
        phoebefeet.SetActive(false);
        phoebecolorway.SetActive(true);
        PlayerPhoebe.GetComponent<SimpleController>().enabled = false;
        Debug.Log("phoebecontrollershouldbeoff");
        outsideRookeryTrigger.GetComponent<Collider>().enabled = false;
        outsideRookeryTrigger.GetComponent<DialogueTrigger>().enabled = false;
        insideRookeryTrigger.GetComponent<DialogueTrigger>().enabled = false;
        //switch camera to Fen
        yield return new WaitForSeconds(4f);
        audioManager.SetActive(false);
        gardenYarnTrigger.SetActive(false);
        phoebecam01.Priority = 0;
        phoebecamfirstPerson.Priority = 0;
        fenCam01.Priority = 12;
        Debug.Log("camshouldswitch");
        //PlayerPhoebe.gameObject.SetActive(false);
        //Debug.Log("phoebeoff");
        yield return new WaitForSeconds(5f);
        //zoom in to Fen
        fenCam02.Priority = 12;
        //fenCam01.gameObject.SetActive(false);
        fenCam01.Priority = 1;
        //set charPOV to diviner
        yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Diviner);
        //turn on Fen controller
        PlayerFen.GetComponent<SimpleController>().enabled = true;
        yield return new WaitForSeconds(1f);
        //turn off Fen's dialogue trigger from tavern scene
        yarnDialogueTrigger.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        //start the mini cutscene
        timelineScript.GoTimeline();
        fencolorway.gameObject.SetActive(false);
        outsideRookeryTrigger.gameObject.SetActive(false);
        Debug.Log("switched to fen");
        StopCoroutine(WaitSwitchtoFen());
    }
}
