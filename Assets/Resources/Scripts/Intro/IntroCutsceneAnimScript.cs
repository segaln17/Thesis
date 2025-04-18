using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutsceneAnimScript : MonoBehaviour
{
    [Header("Animators")] 
    public Animator fighterAnim;
    public Animator flytrapAnim;
    public Animator flytrapShadowAnim;
    

    [Header("GameObjects")] 
    public GameObject fighter;

    public GameObject dialogueTriggerWait;
    public GameObject dialogueTriggerFight;
    public GameObject fighterShadow;
    public GameObject flytrapShadowSprite;
    public GameObject flytrapShadowDecal;

    public GameObject blinkingObj;
    public GameObject tessObj;
    public GameObject healthCanvas;
    public GameObject buttonCanvas;

    
    public GameObject flyTrap;
    public GameObject slashObject;
    public GameObject sparkleObject;
    public GameObject shatter02;
    public GameObject phoebefeet;
    public AudioSource swoop;
    public CinemachineVirtualCamera fighterPOV;
    public GameObject mainCam01;
    public CinemachineVirtualCamera firstpersonpovtransition;
    public GameObject playerv1;
    public GameObject playerv2;
    public GameObject bigPhoebesprite;

    public GameObject audioManager;
   

    [Header("Buttons")] 
    public Button fightFlytrapButton;

    public Button fightFlytrapFinalButton;
    public Button waitFlytrapButton;
    public Button waitFlytrapFinalButton;
    public Button fleeButton;
    
    
    [Header("Audio")] 
    public AudioSource fightSounds;
    public AudioClip shriek;
    public AudioClip slash;
    public AudioSource fightSongs;
    public AudioClip beatLoop;
    public AudioClip sighLoop;

    [Header("Conditions")] 
    private bool paused = false;
    public string animFlytrapName;
    public string animFlytrapWaitName;
    

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        dialogueTriggerWait.SetActive(false);
        dialogueTriggerFight.SetActive(false);
        fightFlytrapButton.gameObject.SetActive(false);
        waitFlytrapButton.gameObject.SetActive(false);
        fleeButton.gameObject.SetActive(false);
        audioManager.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    { 
    }
//-----------------FLYTRAP-------------------//
    public void FlyTrapTrigger()
    {
        paused = true;
        fightFlytrapButton.gameObject.SetActive(true);
        waitFlytrapButton.gameObject.SetActive(true);
        fleeButton.gameObject.SetActive(true);
        Debug.Log("collided");
    }

    public void FlyTrapFight()
    {
        
        //slashObject.SetActive(true);
        fightSounds.PlayOneShot(slash);
        fightSounds.PlayOneShot(shriek);
        dialogueTriggerFight.SetActive(true);
        fightFlytrapButton.gameObject.SetActive(false);
        fightFlytrapFinalButton.gameObject.SetActive(false);
        waitFlytrapButton.gameObject.SetActive(false);
        waitFlytrapFinalButton.gameObject.SetActive(false);
        fleeButton.gameObject.SetActive(false);
        buttonCanvas.SetActive(false);
        //fighter.GetComponent<SimpleController>().enabled = true;
        playerv1.SetActive(false);
        firstpersonpovtransition.Priority = 30;
        shatter02.SetActive(true);
        phoebefeet.SetActive(true);
        fighterShadow.SetActive(true);
        swoop.Play();
        healthCanvas.SetActive(false);
        //fighterPOV.Priority = 15;
        
      

        if (flytrapAnim != null)
        {
            flytrapAnim.Play(animFlytrapName);
            
        }
        if (flytrapShadowAnim != null)
        {
            flytrapShadowAnim.Play(animFlytrapName);
        }
        StartCoroutine(flytrapDie());
    }

    public void FlytrapWait()
    {
        sparkleObject.SetActive(true);
        dialogueTriggerWait.SetActive(true);
        fightFlytrapButton.gameObject.SetActive(false);
        waitFlytrapButton.gameObject.SetActive(false);
        waitFlytrapFinalButton.gameObject.SetActive(false);
        fleeButton.gameObject.SetActive(false);
        buttonCanvas.SetActive(false);
        fighter.GetComponent<SimpleController>().enabled = true;
        shatter02.SetActive(true);
        phoebefeet.SetActive(true);
        fighterShadow.SetActive(true);
        swoop.Play();
        mainCam01.SetActive(false);
        healthCanvas.SetActive(false);
        fighterPOV.Priority = 15;
        blinkingObj.SetActive(true);
        tessObj.SetActive(true);
        audioManager.SetActive(true);

        if (flytrapAnim != null)
        {
            flytrapAnim.Play(animFlytrapWaitName);
            
        }

        if (flytrapShadowAnim != null)
        {
            flytrapShadowAnim.Play(animFlytrapWaitName);
        }


    }

    IEnumerator flytrapDie()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(flyTrap);
        Destroy(flytrapShadowSprite);
        Destroy(flytrapShadowDecal);
        yield return new WaitForSeconds(5f);
        mainCam01.SetActive(false);
        fighterPOV.Priority = 20;
        yield return new WaitForSeconds(1f);
        bigPhoebesprite.SetActive(false);
        playerv2.SetActive(true);
        playerv2.GetComponent<SimpleController>().enabled = true;
        blinkingObj.SetActive(true);
        tessObj.SetActive(true);
        audioManager.SetActive(true);
        
    }
    

}
