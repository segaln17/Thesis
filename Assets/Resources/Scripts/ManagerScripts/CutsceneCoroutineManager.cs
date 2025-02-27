using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutsceneCoroutineManager : MonoBehaviour
{
    [Header("Yarn Triggers")]
    public DialogueTrigger outsideRookeryTrigger;
    public DialogueTrigger insideRookeryTrigger;
    public YarnDialogueTrigger yarnDialogueTrigger;

    public TimelineTest timelineScript;

    [Header("Main Characters")]
    public GameObject PlayerPhoebe;
    public GameObject PlayerFen;
    //public GameObject PlayerAltea;

    [Header("Maini Character Postions")]
    public GameObject fenBonfirePosition;

    [Header("NPC Characters")]
    public GameObject Windy;
    public GameObject Heloise;
    //public GameObject Grimbolde;

    [Header("NPC Character Locations")]
    public GameObject HeloiseCampfireCutscenePosition;
    //public GameObject WindyPosition02;
    //public GameObject Hildegarde;
    //public GameObject Grimbolde;

    [Header("Cameras")]
    public CinemachineVirtualCamera pulsingCamera;
    //
    public CinemachineVirtualCamera phoebecamfirstPerson;
    public CinemachineVirtualCamera phoebecamthirdPerson;
    //
    public CinemachineVirtualCamera fenfirstPerson;
    public CinemachineVirtualCamera fenthirdPerson;
    public CinemachineVirtualCamera fenthirdPersonTavern;
    //
    public CinemachineVirtualCamera GardenAerialCam;
    

    [Header("Phoebe POV Assets")]
    public Rigidbody PhoebeRB;
    public GameObject phoebefeetSprite;
    public GameObject phoebeFullBodySprite;
    public GameObject audioManager;
    public GameObject phoebeTess;


    [Header("Fen POV Assets")]
    public Rigidbody fenRb;
    public GameObject fenfeetSprite;
    public GameObject fenFullBodySpriteSitting;
    public GameObject fenFullBodySpriteStanding;
    public GameObject fenTess;

    [Header("Effects")]
    public AudioSource transitionAudio;
    public AudioClip transitionClip;
    public GameObject hyperSpaceWarp;
    public bool isPulsing = false;
    public bool isNormal = false;

    public int normal = 60;
    public int zoom = 30;
    public float smooth = 5;

    [Header("Important Objects")]
    public GameObject gameManager;
    //garden cutscene coroutine
    public GameObject stableLight;
    //stable cutscene coroutine
    public GameObject stableYarnTrigger;
    

    /////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        stableLight.SetActive(false);
        pulsingCamera = phoebecamfirstPerson;

    }

    /////////////////////////////////////////////////////
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
    /////////////////////////////////////////////////////
    ///------PHOEBE TO FEN FROM GARDEN POST ROOKERY---///
    public IEnumerator PtoFfromGarden()
    {
        Debug.Log("switching to Fen from Garden");
        //first person POV to third person POV
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        //first pulse
        phoebecamfirstPerson.Priority = 1;
        phoebecamthirdPerson.Priority = 12;
        pulsingCamera = phoebecamthirdPerson;
        phoebefeetSprite.SetActive(false);
        phoebeTess.SetActive(false);
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        //second pulse finish phoebeto third person
        Debug.Log("phoebethirdperson");

        PhoebeRB.isKinematic = true;
        phoebeFullBodySprite.SetActive(true);
        PlayerPhoebe.GetComponent<SimpleController>().enabled = false;
        audioManager.SetActive(false);
        Debug.Log("phoebecontrollershouldbeoff");

        //Phoebe controllers off and colliders off
        outsideRookeryTrigger.GetComponent<Collider>().enabled = false;
        outsideRookeryTrigger.GetComponent<DialogueTrigger>().enabled = false;
        insideRookeryTrigger.GetComponent<DialogueTrigger>().enabled = false;
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        //third pulse finish

        //switch camera to Garden Aerial Camera
        yield return new WaitForSeconds(1.5f);

        phoebecamthirdPerson.Priority = 0;
        phoebecamfirstPerson.Priority = 0;
        hyperSpaceWarp.SetActive(true);
        GardenAerialCam.Priority = 12;
        pulsingCamera = fenthirdPersonTavern;


        //switch camera to Fen Third Person
        yield return new WaitForSeconds(1.35f);
        transitionAudio.PlayOneShot(transitionClip);

        GardenAerialCam.Priority = 0;
        fenthirdPersonTavern.Priority = 12;
        yield return new WaitForSeconds(1f);
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1f);
        isPulsing = false;
        isNormal = true;
        //fourth pulse finish
        Debug.Log("camshouldswitch");

        yield return new WaitForSeconds(1.5f);
        pulsingCamera = fenfirstPerson;
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        //fifth pulse finish



        //zoom in to Fen First Person
        fenfirstPerson.Priority = 12;
        fenthirdPersonTavern.Priority = 0;

        hyperSpaceWarp.SetActive(true);
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        yield return new WaitForSeconds(.5f);
        //Sixth pulse finish

        //set charPOV to diviner
        gameManager.GetComponent<GameManager>().currentPOV = GameManager.CharacterPOV.Diviner;
        //turn off Fen's dialogue trigger from tavern scene
        yarnDialogueTrigger.gameObject.SetActive(false);
        //start the mini cutscene
        timelineScript.GoTimeline();
        //turning on fen elements
        fenRb.isKinematic = false;
        fenTess.SetActive(true);
        fenfeetSprite.SetActive(true);
        fenFullBodySpriteSitting.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        //Seventh pulse finish

        //turn on Fen controller
        PlayerFen.GetComponent<SimpleController>().enabled = true;
        
        yield return new WaitForSeconds(1.5f);
        isNormal = false;

        //resetting all elements
        fenfirstPerson.m_Lens.FieldOfView = 60f;
        fenthirdPerson.m_Lens.FieldOfView = 60f;
        fenthirdPersonTavern.m_Lens.FieldOfView = 60f;
        phoebecamthirdPerson.m_Lens.FieldOfView = 60f;
        phoebecamfirstPerson.m_Lens.FieldOfView = 60f;
        GardenAerialCam.m_Lens.FieldOfView = 60f;
        phoebecamthirdPerson.Priority = 0;
        phoebecamfirstPerson.Priority = 0;

        outsideRookeryTrigger.gameObject.SetActive(false);
        Debug.Log("switched to fen completed");
        StopCoroutine(PtoFfromGarden());
    }

    /////////////////////////////////////////////////////
    ///------FEN TO PHOEBE POST STABLE---///
    public IEnumerator FtoPpostStable()
    {
        //first person POV to third person POV
        Debug.Log("switching to Phoebe");
        stableYarnTrigger.SetActive(false);
        pulsingCamera = fenfirstPerson;
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        hyperSpaceWarp.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        //pulse 1
        
        yield return new WaitForSeconds(3f);
        fenfirstPerson.Priority = 0;
        fenthirdPerson.Priority = 12;
        


        Debug.Log("third POV Fen");
        pulsingCamera = fenthirdPerson;
        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        fenFullBodySpriteStanding.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        //pulse 2

        //Fen first person elements and controller off
        fenfeetSprite.SetActive(false);
        PlayerFen.GetComponent<SimpleController>().enabled = false;
        fenRb.isKinematic = true;
        fenTess.SetActive(false);
        //turn off Fen controls

        yield return new WaitForSeconds(1.5f);

        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        hyperSpaceWarp.SetActive(true);
        //pulse 3

        //switch to garden aerial cam
        pulsingCamera = phoebecamthirdPerson;
        yield return new WaitForSeconds(1.5f);
        GardenAerialCam.Priority = 12;
        fenfirstPerson.Priority = 0;
        fenthirdPerson.Priority = 0;
        fenFullBodySpriteStanding.SetActive(false);
        yield return new WaitForSeconds(2.5f);

        //Switch to Phooebe third Person
        phoebecamthirdPerson.Priority = 12;
        GardenAerialCam.Priority = 0;

        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        hyperSpaceWarp.SetActive(true);
        //pulse 4

        //Switch Phoebe first Person
        pulsingCamera = phoebecamfirstPerson;
        yield return new WaitForSeconds(2.5f);
        phoebecamfirstPerson.Priority = 12;
        phoebecamthirdPerson.Priority = 0;

        isPulsing = true;
        transitionAudio.PlayOneShot(transitionClip);
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        hyperSpaceWarp.SetActive(true);
        //pulse 5

        //set charPOV to Fighter
        //yarnDialogueTrigger.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        //yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Fighter);
        gameManager.GetComponent<GameManager>().currentPOV = GameManager.CharacterPOV.Fighter;

        Debug.Log("fighterPOV gamemanager check");

        yield return new WaitForSeconds(2f);
        //turn on Phoebe controls
        PlayerPhoebe.GetComponent<SimpleController>().enabled = true;
        PhoebeRB.isKinematic = (false);
        phoebefeetSprite.SetActive(true);
        phoebeFullBodySprite.SetActive(false);
        audioManager.SetActive(true);
        phoebeTess.SetActive(true);

        //Reposition Fen
        yield return new WaitForSeconds(1f);
        PlayerFen.transform.position = fenBonfirePosition.transform.position;
        Heloise.transform.position = HeloiseCampfireCutscenePosition.transform.position;
        fenFullBodySpriteSitting.SetActive(true);
        

        //Reset
        yield return new WaitForSeconds(1f);
        fenfirstPerson.m_Lens.FieldOfView = 60f;
        fenthirdPerson.m_Lens.FieldOfView = 60f;
        fenthirdPersonTavern.m_Lens.FieldOfView = 60f;
        phoebecamthirdPerson.m_Lens.FieldOfView = 60f;
        phoebecamfirstPerson.m_Lens.FieldOfView = 60f;
        GardenAerialCam.m_Lens.FieldOfView = 60f;

        Debug.Log("switched to Phoebe");
        StopCoroutine(FtoPpostStable());
    }
}
