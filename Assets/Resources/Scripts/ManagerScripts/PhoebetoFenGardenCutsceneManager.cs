using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PhoebetoFenGardenCutsceneManager : MonoBehaviour
{
    [Header("Yarn Triggers")]
    public DialogueTrigger outsideRookeryTrigger;
    public DialogueTrigger insideRookeryTrigger;
    public YarnDialogueTrigger yarnDialogueTrigger;

    public TimelineTest timelineScript;

    [Header("Characters")]
    public GameObject PlayerPhoebe;
    public GameObject PlayerFen;


    [Header("Cameras")]
    public CinemachineVirtualCamera fenCam01;
    public CinemachineVirtualCamera fenCam02;
    public CinemachineVirtualCamera phoebecamfirstPerson;
    public CinemachineVirtualCamera phoebecam01;
    public CinemachineVirtualCamera AerialCam;

    public CinemachineVirtualCamera pulsingCamera;

    [Header("POV Assets")]
    public Rigidbody PhoebeRB;
    public GameObject phoebefeet;
    public GameObject phoebecolorway;
    public GameObject fencolorway;
    public GameObject gardenYarnTrigger;
    public GameObject audioManager;
    public GameObject phoebeTess;
    public GameObject fenTess;

    public GameObject hyperSpaceWarp;
    public bool isPulsing = false;
    public bool isNormal = false;
    
    public int normal = 60;
    public int zoom = 30;
    public float smooth = 5;
  

    public GameObject stableLight;

    

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
        stableLight.SetActive(false);
        pulsingCamera = phoebecamfirstPerson;
        
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

       
        if (isPulsing)
        {
            pulsingCamera.m_Lens.FieldOfView = Mathf.Lerp(pulsingCamera.m_Lens.FieldOfView, zoom, Time.deltaTime * smooth);
        }
        else if(!isPulsing && isNormal)
        {
            pulsingCamera.m_Lens.FieldOfView = Mathf.Lerp(pulsingCamera.m_Lens.FieldOfView, normal, Time.deltaTime * smooth);
        }


    }

    IEnumerator WaitSwitchtoFen()
    {
        Debug.Log("switching to Fen from Garden");
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;

        phoebecamfirstPerson.Priority = 1;
        phoebecam01.Priority = 12;
        pulsingCamera = phoebecam01;
        phoebefeet.SetActive(false);
        phoebeTess.SetActive(false);
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        Debug.Log("phoebethirdperson");
        PhoebeRB.isKinematic = true;
        
        phoebecolorway.SetActive(true);
        PlayerPhoebe.GetComponent<SimpleController>().enabled = false;
        Debug.Log("phoebecontrollershouldbeoff");
        outsideRookeryTrigger.GetComponent<Collider>().enabled = false;
        outsideRookeryTrigger.GetComponent<DialogueTrigger>().enabled = false;
        insideRookeryTrigger.GetComponent<DialogueTrigger>().enabled = false;
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;

        //switch camera to Aerial
        yield return new WaitForSeconds(1.5f);
        audioManager.SetActive(false);
        gardenYarnTrigger.SetActive(false);
        phoebecam01.Priority = 0;
        phoebecamfirstPerson.Priority = 0;
        hyperSpaceWarp.SetActive(true);
        AerialCam.Priority = 12;
        pulsingCamera = fenCam01;
        yield return new WaitForSeconds(1f);


        //switch camera to Fen
        yield return new WaitForSeconds(1.15f);
        AerialCam.Priority = 0;
        fenCam01.Priority = 12;
        yield return new WaitForSeconds(1f);
        isPulsing = true;
        yield return new WaitForSeconds(1f);
        isPulsing = false;
        isNormal = true;
        Debug.Log("camshouldswitch");
        yield return new WaitForSeconds(1.5f);
        pulsingCamera = fenCam02;
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;


        //zoom in to Fen
        fenCam02.Priority = 12;
        fenCam01.Priority = 1;
        fenTess.SetActive(true);
        hyperSpaceWarp.SetActive(true);
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        yield return new WaitForSeconds(.5f);

        //set charPOV to diviner
        yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Diviner);
        //turn on Fen controller
        PlayerFen.GetComponent<SimpleController>().enabled = true;
        yield return new WaitForSeconds(1f);
        //turn off Fen's dialogue trigger from tavern scene
        yarnDialogueTrigger.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        //start the mini cutscene
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        yield return new WaitForSeconds(1.5f);
        isNormal = false;
        fenCam02.m_Lens.FieldOfView = 60f;
        timelineScript.GoTimeline();
        fencolorway.gameObject.SetActive(false);
        outsideRookeryTrigger.gameObject.SetActive(false);
        //hyperSpaceWarp.SetActive(false);
        Debug.Log("switched to fen");
        StopCoroutine(WaitSwitchtoFen());
    }


}
