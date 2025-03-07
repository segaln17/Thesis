using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PhoebetoooFenSpine : MonoBehaviour
{
    public GameObject gameManager;
    
    [Header("Yarn Triggers")]
    public YarnDialogueTrigger yarnDialogueTrigger;

    public TimelineTest timelineScript;

    [Header("Characters")]
    public GameObject PlayerPhoebe;
    public GameObject PlayerFen;
    public GameObject spineBridge;
   

    [Header("Cameras")]
    public CinemachineVirtualCamera fenCam01;
    public CinemachineVirtualCamera fenCam02;
    public CinemachineVirtualCamera phoebecamfirstPerson;
    public CinemachineVirtualCamera phoebecam01;
    public CinemachineVirtualCamera AerialCam;

    public CinemachineVirtualCamera pulsingCamera;

    [Header("POV Assets")]
    public Rigidbody PhoebeRB;
    public Rigidbody fenRb;
    public GameObject phoebefeet;
    public GameObject fenFeet;
    public GameObject phoebecolorway;
    public GameObject fencolorway;
    public GameObject alteacutsceneTrigger;
    public GameObject audioManager;
    public GameObject phoebeTess;
    public GameObject fenTess;

    public GameObject hyperSpaceWarp;
    public bool isPulsing = false;
    public bool isNormal = false;

    public int normal = 60;
    public int zoom = 30;
    public float smooth = 5;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");

        pulsingCamera = phoebecamfirstPerson;

    }

    // Update is called once per frame
    void Update()
    {
       
        if (isPulsing)
        {
            pulsingCamera.m_Lens.FieldOfView = Mathf.Lerp(pulsingCamera.m_Lens.FieldOfView, zoom, Time.deltaTime * smooth);
        }
        else if (!isPulsing && isNormal)
        {
            pulsingCamera.m_Lens.FieldOfView = Mathf.Lerp(pulsingCamera.m_Lens.FieldOfView, normal, Time.deltaTime * smooth);
        }


    }

    IEnumerator SwitchtoFenSecond()
    {
        Debug.Log("switching to Fen from Spine");
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;

        phoebefeet.SetActive(false);
        phoebecamfirstPerson.Priority = 1;
        phoebecam01.Priority = 12;
        pulsingCamera = phoebecam01;
        
        phoebeTess.SetActive(false);
        hyperSpaceWarp.SetActive(true);
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
       

        //switch camera to Aerial
        yield return new WaitForSeconds(1.5f);
        audioManager.SetActive(false);
        alteacutsceneTrigger.SetActive(false);
        phoebecam01.Priority = 0;
        phoebecamfirstPerson.Priority = 0;
        hyperSpaceWarp.SetActive(true);
        AerialCam.Priority = 12;
        pulsingCamera = fenCam01;
       
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        yield return new WaitForSeconds(1f);


        //switch camera to Fen
        yield return new WaitForSeconds(1.15f);
        AerialCam.Priority = 0;
        fenCam01.Priority = 12;
        fencolorway.gameObject.SetActive(true);
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
        
        gameManager.GetComponent<GameManager>().currentPOV = GameManager.CharacterPOV.Diviner;

        //set charPOV to diviner
        //yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Diviner);
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
        
        fenCam01.m_Lens.FieldOfView = 60f;
        fenCam02.m_Lens.FieldOfView = 60f;
        phoebecam01.m_Lens.FieldOfView = 60f;
        phoebecamfirstPerson.m_Lens.FieldOfView = 60f;
        timelineScript.GoTimeline();
        fencolorway.gameObject.SetActive(false);
        fenFeet.SetActive(true);
        //hyperSpaceWarp.SetActive(false);
        Debug.Log("switched to fen");
        StopCoroutine(SwitchtoFenSecond());
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("SwitchtoFenSecond");
        }
    }

}
