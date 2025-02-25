using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PhoebetoFenGardenCutsceneManager : MonoBehaviour
{
    [Header("Yarn Triggers")]
    public DialogueTrigger outsideRookeryTrigger;
    public GameObject coroutineManager;

    

    // Start is called before the first frame update
    void Start()
    {
        //audioManager = GameObject.Find("AudioManager");
        //phoebeTess = GameObject.Find("GameManager/Canvas/PhoebeTesselations");
        ///fenTess = GameObject.Find("GameManager/Canvas/FenTesselations");

        //stableLight.SetActive(false);
       // pulsingCamera = phoebecamfirstPerson;

        
      
    }

    // Update is called once per frame
    void Update()
    {
        if (outsideRookeryTrigger.dialoguePlayed)
        {
            StartCoroutine(coroutineManager.GetComponent<CutsceneCoroutineManager>().PtoFfromGarden());
            outsideRookeryTrigger.dialoguePlayed = false;
            
        }

       
       /* if (isPulsing)
        {
            pulsingCamera.m_Lens.FieldOfView = Mathf.Lerp(pulsingCamera.m_Lens.FieldOfView, zoom, Time.deltaTime * smooth);
        }
        else if(!isPulsing && isNormal)
        {
            pulsingCamera.m_Lens.FieldOfView = Mathf.Lerp(pulsingCamera.m_Lens.FieldOfView, normal, Time.deltaTime * smooth);
        }*/


    }

  /*  IEnumerator WaitSwitchtoFen()
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
        fenRb.isKinematic = false;
        
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
        
        yield return new WaitForSeconds(1f);
        //turn off Fen's dialogue trigger from tavern scene
        yarnDialogueTrigger.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        //start the mini cutscene
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        //turn on Fen controller
        PlayerFen.GetComponent<SimpleController>().enabled = true;
        timelineScript.GoTimeline();
        yield return new WaitForSeconds(1.5f);
        isNormal = false;
        fenCam02.m_Lens.FieldOfView = 60f;
        phoebecamfirstPerson.m_Lens.FieldOfView = 60f;
        fenfeet.SetActive(true);
        fencolorway.gameObject.SetActive(false);
        outsideRookeryTrigger.gameObject.SetActive(false);
        //hyperSpaceWarp.SetActive(false);
        Debug.Log("switched to fen");
        StopCoroutine(WaitSwitchtoFen());
    }*/


}
