using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FentoPhoebePostGardenCutsceneManager : MonoBehaviour
{
    [Header("Yarn Triggers")]
    public YarnDialogueTrigger alteaCutsceneTrigger;
    public YarnDialogueTrigger yarnDialogueTrigger;
    public bool cutsceneEndedInCollider;
    public Transform fenBonfire;
    //public RookeryActivate rookeryControls;

    [Header("Characters")]
    public GameObject PlayerPhoebe;

    public GameObject PlayerDiviner;

    public GameObject songManager;

    public GameObject fenColorway;
    public GameObject fenfeet;


    [Header("Cameras")]
    //3rd person Fen
    public CinemachineVirtualCamera fenCam01;
    //1st person Fen
    public CinemachineVirtualCamera fenCam02;
    //3rd person phoebe
    public CinemachineVirtualCamera phoebecam01;
    //first person Phoebe
    public CinemachineVirtualCamera phoebeCam02;
    public CinemachineVirtualCamera gardenAerialCam;
    public CinemachineVirtualCamera pulsingCamera;

    [Header("POV Assets")]
    public GameObject phoebefeet;
    public GameObject phoebecolorway;
    public GameObject phoebetess;
    public GameObject fentess;
    public Rigidbody phoeberb;
    public Rigidbody fenRb;
    

    public bool isswitching;
    public bool isswitched;

    public GameObject hyperSpaceWarp;
    public bool isPulsing = false;
    public bool isNormal = false;

    public int normal = 60;
    public int zoom = 30;
    public float smooth = 5;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        isswitching = false;
        isswitched = false;
        cutsceneEndedInCollider = false;
        PlayerDiviner.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    
    {
        //if (alteaCutsceneTrigger.cutsceneRun)
        if (cutsceneEndedInCollider)
        {
            StartCoroutine("WaitSwitchtoPhoebe");
            //alteaCutsceneTrigger.cutsceneRun;
            gameObject.GetComponent<Collider>().enabled = false;
            cutsceneEndedInCollider = false;
            //alteaCutsceneTrigger.gameObject.SetActive(false);
        }

        if (isPulsing)
        {
            pulsingCamera.m_Lens.FieldOfView = Mathf.Lerp(pulsingCamera.m_Lens.FieldOfView, zoom, Time.deltaTime * smooth);
        }
        else if (!isPulsing && isNormal)
        {
            pulsingCamera.m_Lens.FieldOfView = Mathf.Lerp(pulsingCamera.m_Lens.FieldOfView, normal, Time.deltaTime * smooth);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    //should this be OnTriggerStay?
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            isswitching = true;
            cutsceneEndedInCollider = true;
        }
        
    }
    
    
    IEnumerator WaitSwitchtoPhoebe()
    {
        Debug.Log("switching to Phoebe");
        pulsingCamera = fenCam02;
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        hyperSpaceWarp.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fenColorway.SetActive(true);
        yield return new WaitForSeconds(3f);
        fenCam02.Priority = 1;
        fenCam01.Priority = 12;
        Debug.Log("third POV Fen");
        pulsingCamera = fenCam01;
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        yield return new WaitForSeconds(3f);
        fenColorway.SetActive(false);
        //turn off Fen controls
        PlayerDiviner.GetComponent<SimpleController>().enabled = false;
        fenfeet.SetActive(false);
        //PlayerDiviner.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(3f);
        //switch camera to Phoebe
        //turn Phoebe's gameobject on
        PlayerPhoebe.gameObject.SetActive(true);
        phoebecolorway.SetActive(true);

        
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        hyperSpaceWarp.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        gardenAerialCam.Priority = 12;
        fenCam01.Priority = 0;
        fenCam02.Priority = 0;
        yield return new WaitForSeconds(3f);

        phoebecam01.Priority = 12;
        gardenAerialCam.Priority = 0;
        fenCam01.Priority = 0;
        fenCam02.Priority = 0;
        Debug.Log("camshouldswitch");
        //PlayerDiviner.gameObject.SetActive(false);
        Debug.Log("fen off");
        fenRb.isKinematic = true;
        pulsingCamera = phoebecam01;
        isPulsing = true;
        yield return new WaitForSeconds(1.5f);
        isPulsing = false;
        isNormal = true;
        hyperSpaceWarp.SetActive(true);
        yield return new WaitForSeconds(3f);
        fentess.SetActive(false);
        phoebeCam02.Priority = 12;
        phoebecam01.Priority = 1;
        yield return new WaitForSeconds(3f);
        phoeberb.isKinematic = (false);
        phoebefeet.SetActive(true);
        
        phoebecolorway.SetActive(false);
        //fenCam01.gameObject.SetActive(false);
        //fenCam02.gameObject.SetActive(false);
        PlayerDiviner.transform.position = fenBonfire.position;
        
        //set charPOV to Fighter
        yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Fighter);
        
        //turn on Phoebe controls
        PlayerPhoebe.GetComponent<SimpleController>().enabled = true;
        songManager.SetActive(true);
        phoebetess.SetActive(true);
        yield return new WaitForSeconds(1f);
        fenCam01.m_Lens.FieldOfView = 60f;
        fenCam02.m_Lens.FieldOfView = 60f;
        phoebecam01.m_Lens.FieldOfView = 60f;
        phoebeCam02.m_Lens.FieldOfView = 60f;
        //yarnDialogueTrigger.gameObject.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //timelineScript.GoTimeline();
        Debug.Log("switched to Phoebe");
        StopCoroutine(WaitSwitchtoPhoebe());
    }
}
