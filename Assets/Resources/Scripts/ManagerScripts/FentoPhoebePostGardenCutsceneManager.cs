using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FentoPhoebePostGardenCutsceneManager : MonoBehaviour
{
    public SimpleController divinerController;

    public YarnDialogueTrigger alteaCutsceneTrigger;
    public YarnDialogueTrigger yarnDialogueTrigger;
    
    public RookeryActivate rookeryControls;

    public GameObject PlayerPhoebe;

    public GameObject PlayerDiviner;
    //3rd person Fen
    public CinemachineVirtualCamera fenCam01;
    //1st person Fen
    public CinemachineVirtualCamera fenCam02;
    //3rd person phoebe
    public CinemachineVirtualCamera phoebecam01;

    //public GameObject fensprite;
    public GameObject phoebefeet;
    public GameObject phoebecolorway;
    public bool isswitching;
    public bool isswitched;
    // Start is called before the first frame update
    void Start()
    {
        isswitching = false;
        isswitched = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (alteaCutsceneTrigger.cutsceneRun)
        {
            StartCoroutine("WaitSwitchtoPhoebe");
        }
        */
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            isswitching = true;
        }
        
    }
    
    IEnumerator FenReveal()
    {
        yield return new WaitForSeconds(2f);
        rookeryControls.firstPerson.Priority = 1;
        fenCam02.Priority = 1;
        fenCam01.Priority = 12;
        //fensprite.SetActive(true);
        //phoebecam01.Priority = 12;
        //phoebefeet.SetActive(false);
        //phoebecolorway.SetActive(true);
        //PlayerPhoebe.GetComponent<SimpleController>().enabled = false;
        isswitched = true;
        StopCoroutine(FenReveal());

    }
    
    IEnumerator WaitSwitchtoPhoebe()
    {
        yield return new WaitForSeconds(2f);
        divinerController.GetComponent<SimpleController>().enabled = false;
        
        //switch camera to Phoebe
        phoebecam01.Priority = 12;
        rookeryControls.firstPerson.Priority = 1;
        fenCam01.Priority = 0;
        yield return new WaitForSeconds(4f);
        rookeryControls.firstPerson.Priority = 12;
        phoebecam01.Priority = 1;
        fenCam02.gameObject.SetActive(false);
        fenCam02.Priority = 1;
        fenCam01.gameObject.SetActive(false);
        fenCam01.Priority = 1;
        yarnDialogueTrigger.SetCharacterPOV(GameManager.CharacterPOV.Fighter);
        PlayerPhoebe.GetComponent<SimpleController>().enabled = true;
        yield return new WaitForSeconds(1f);
        //yarnDialogueTrigger.gameObject.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //timelineScript.GoTimeline();
    }
}
