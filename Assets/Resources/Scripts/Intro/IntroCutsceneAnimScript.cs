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
    public Animator blinker;
    public Animator largePhoebe;
    public Animator fighterShadowAnim;
    

    [Header("GameObjects")] 
    public GameObject fighter;
    public GameObject shatterflat;


    public GameObject dialogueTriggerWait;
    public GameObject dialogueTriggerFight;
    public GameObject fighterShadow;
    public GameObject flytrapShadowSprite;
    public GameObject flytrapShadowDecal;

    public GameObject blinkingObj;
    public GameObject tessObj;
    public GameObject healthCanvas;
    public GameObject buttonCanvas;
    public GameObject buttonBorder;
    public GameObject damage;
    public GameObject slash02;
    public Animator flytrapWaitedAnim;

    
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
    public AudioClip hss;
    public AudioSource beatLoopBattle;
    public AudioSource fightSongs02;
    public AudioClip slashhit2;
    public AudioClip shriekhit2;

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
        buttonBorder.SetActive(false);
       
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
        buttonBorder.SetActive(true);
        Debug.Log("collided");
    }

    public void FlyTrapFight()
    {
        fightFlytrapButton.gameObject.SetActive(false);
        fightFlytrapFinalButton.gameObject.SetActive(false);
        waitFlytrapButton.gameObject.SetActive(false);
        waitFlytrapFinalButton.gameObject.SetActive(false);
        fleeButton.gameObject.SetActive(false);
        buttonCanvas.SetActive(false);
        
        /*if (flytrapAnim != null)
        {
            flytrapAnim.Play(animFlytrapName);
            
        }
        if (flytrapShadowAnim != null)
        {
            flytrapShadowAnim.Play(animFlytrapName);
        }*/
        StartCoroutine(flytrapDie());
    }

    public void FlytrapWait()
    {
        //sparkleObject.SetActive(true);
        dialogueTriggerWait.SetActive(true);
        fightFlytrapButton.gameObject.SetActive(false);
        waitFlytrapButton.gameObject.SetActive(false);
        waitFlytrapFinalButton.gameObject.SetActive(false);
        fleeButton.gameObject.SetActive(false);
        buttonCanvas.SetActive(false);

   
        StartCoroutine(flytrapWaited());

    }

    IEnumerator flytrapDie()
    {
        largePhoebe.SetBool("fight", true);
        fighterShadowAnim.SetBool("fight", true);
        yield return new WaitForSeconds(1f);
        fightSounds.PlayOneShot(slash);
        fightSongs02.PlayOneShot(slashhit2);
        yield return new WaitForSeconds(.5f);   
        slashObject.SetActive(true);
        slash02.SetActive(true);
        sparkleObject.SetActive(true);
        damage.SetActive(true);
        yield return new WaitForSeconds(1f);
        fightSounds.PlayOneShot(shriek);
        fightSongs02.PlayOneShot(shriekhit2);
        flytrapAnim.Play(animFlytrapName);
        flytrapShadowAnim.Play(animFlytrapName);
        yield return new WaitForSeconds(1f);
        Destroy(flyTrap);
        Destroy(flytrapShadowSprite);
        Destroy(flytrapShadowDecal);
        yield return new WaitForSeconds(2f);
        largePhoebe.SetBool("fight", false);
        fighterShadowAnim.SetBool("fight", false);
        dialogueTriggerFight.SetActive(true);
        playerv1.SetActive(false);
        firstpersonpovtransition.Priority = 30;
        shatter02.SetActive(true);
        shatterflat.SetActive(true);
        phoebefeet.SetActive(true);
        fighterShadow.SetActive(true);
        swoop.Play();
        healthCanvas.SetActive(false);
        yield return new WaitForSeconds(2f);
        blinkingObj.SetActive(true);
        blinker.SetBool("blinking", true);
        yield return new WaitForSeconds(.1f);
        fighterPOV.Priority = 20;
        mainCam01.SetActive(false);
        yield return new WaitForSeconds(.4f);
        blinker.SetBool("blinkinghold", true);
        yield return new WaitForSeconds(1f);
        bigPhoebesprite.SetActive(false);
        yield return new WaitForSeconds(1f);
        blinker.SetBool("blinkinghold", false);
        blinker.SetBool("blinking", false);
        playerv2.SetActive(true);
        tessObj.SetActive(true);
        audioManager.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerv2.GetComponent<SimpleController>().enabled = true;
        fighterPOV.GetComponent<PlayerCam>().enabled = true;
        fightSongs02.pitch = 0.85f;
        fightSongs02.PlayOneShot(slashhit2);
        fightSounds.PlayOneShot(shriek);
        beatLoopBattle.pitch = 0.85f;
        
    
    }

    IEnumerator flytrapWaited()
    {
        fightSongs02.PlayOneShot(hss);
        fightSounds.PlayOneShot(shriekhit2);
        flytrapAnim.Play(animFlytrapWaitName);
        flytrapShadowAnim.Play(animFlytrapWaitName);
        yield return new WaitForSeconds(5f);
        fightSounds.PlayOneShot(shriek);
        fightSongs02.PlayOneShot(shriekhit2);
        flytrapWaitedAnim.SetBool("waited", true);
        playerv1.SetActive(false);
        firstpersonpovtransition.Priority = 30;
        shatter02.SetActive(true);
        shatterflat.SetActive(true);
        phoebefeet.SetActive(true);
        fighterShadow.SetActive(true);
        swoop.Play();
        healthCanvas.SetActive(false);
        yield return new WaitForSeconds(2f);
        blinkingObj.SetActive(true);
        blinker.SetBool("blinking", true);
        yield return new WaitForSeconds(.1f);
        fighterPOV.Priority = 20;
        mainCam01.SetActive(false);
        yield return new WaitForSeconds(.4f);
        blinker.SetBool("blinkinghold", true);
        yield return new WaitForSeconds(1f);
        bigPhoebesprite.SetActive(false);
        yield return new WaitForSeconds(1f);
        blinker.SetBool("blinkinghold", false);
        blinker.SetBool("blinking", false);
        playerv2.SetActive(true);
        tessObj.SetActive(true);
        audioManager.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerv2.GetComponent<SimpleController>().enabled = true;
        fighterPOV.GetComponent<PlayerCam>().enabled = true;
        fightSongs02.pitch = 0.75f;
        fightSongs02.PlayOneShot(slashhit2);
        fightSounds.PlayOneShot(shriek);
        beatLoopBattle.pitch = 0.75f;
    }
    

}
