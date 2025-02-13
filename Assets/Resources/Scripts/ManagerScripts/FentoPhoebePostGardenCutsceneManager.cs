using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FentoPhoebePostGardenCutsceneManager : MonoBehaviour
{
    public YarnDialogueTrigger alteaCutsceneTrigger;
    public YarnDialogueTrigger yarnDialogueTrigger;
    
    //public RookeryActivate rookeryControls;

    public GameObject PlayerPhoebe;

    public GameObject PlayerDiviner;

    public GameObject songManager;

    public GameObject fenColorway;
    public GameObject fenfeet;
    
    //3rd person Fen
    public CinemachineVirtualCamera fenCam01;
    //1st person Fen
    public CinemachineVirtualCamera fenCam02;
    //3rd person phoebe
    public CinemachineVirtualCamera phoebecam01;
    //first person Phoebe
    public CinemachineVirtualCamera phoebeCam02;
    
    public GameObject phoebefeet;
    public GameObject phoebecolorway;

    public bool isswitching;
    public bool isswitched;

    public bool cutsceneEndedInCollider;
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
        yield return new WaitForSeconds(0.5f);
        fenColorway.SetActive(true);
        yield return new WaitForSeconds(3f);
        fenCam02.Priority = 1;
        fenCam01.Priority = 12;
        Debug.Log("third POV Fen");
        yield return new WaitForSeconds(3f);
        fenColorway.SetActive(false);
        //turn off Fen controls
        PlayerDiviner.GetComponent<SimpleController>().enabled = false;
        PlayerDiviner.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(3f);
        //switch camera to Phoebe
        //turn Phoebe's gameobject on
        PlayerPhoebe.gameObject.SetActive(true);
        phoebecolorway.SetActive(true);
        phoebecam01.Priority = 12;
        fenCam01.Priority = 0;
        fenCam02.Priority = 0;
        Debug.Log("camshouldswitch");
        //PlayerDiviner.gameObject.SetActive(false);
        Debug.Log("fen off");
        yield return new WaitForSeconds(3f);
        phoebeCam02.Priority = 12;
        phoebecam01.Priority = 1;
        yield return new WaitForSeconds(3f);
        phoebefeet.SetActive(true);
        phoebecolorway.SetActive(false);
        fenCam01.gameObject.SetActive(false);
        fenCam02.gameObject.SetActive(false);
        
        //set charPOV to Fighter
        yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Fighter);
        
        //turn on Phoebe controls
        PlayerPhoebe.GetComponent<SimpleController>().enabled = true;
        songManager.SetActive(true);
        yield return new WaitForSeconds(1f);
        //yarnDialogueTrigger.gameObject.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //timelineScript.GoTimeline();
        Debug.Log("switched to Phoebe");
        StopCoroutine(WaitSwitchtoPhoebe());
    }
}
