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
    public Animator huskAnim;
    //public Animator walkAnim;

    [Header("GameObjects")] 
    public GameObject fighter;

    public GameObject dialogueTrigger;

    //public GameObject fighter02;
    public GameObject flyTrap;
    public GameObject husk;
    public GameObject slashObject;
    public GameObject sparkleObject;
    public GameObject shatter02;
    public GameObject phoebefeet;
    public AudioSource swoop;
    public CinemachineVirtualCamera fighterPOV;
    public GameObject mainCam01;
    
    [Header("Buttons")] 
    public Button fightFlytrapButton;
    public Button waitFlytrapButton;
    public Button fightHuskButton;
    public Button waitHuskButton;
    
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
    public string animHuskName;
    
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        dialogueTrigger.SetActive(false);
        //Time.timeScale = 1;
        fightFlytrapButton.gameObject.SetActive(false);
        waitFlytrapButton.gameObject.SetActive(false);
        fightHuskButton.gameObject.SetActive(false);
        waitHuskButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { //put this here, not sure yet if it works but will with testing
        /*if (!paused)
        {
            Time.timeScale = 1;
            //fighter.GetComponent<CutsceneController>().enabled = true;
            fighter.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            Time.timeScale = 0;
            //fighter.GetComponent<CutsceneController>().enabled = false;
            fighter.GetComponent<Rigidbody>().isKinematic = true;
            walkAnim.SetBool("isWalking", false);
        }*/
    }
//-----------------FLYTRAP-------------------//
    public void FlyTrapTrigger()
    {
        paused = true;
        fightFlytrapButton.gameObject.SetActive(true);
        waitFlytrapButton.gameObject.SetActive(true);
        Debug.Log("collided");
    }

    public void FlyTrapFight()
    {
        slashObject.SetActive(true);
        fightSounds.PlayOneShot(slash);
        fightSounds.PlayOneShot(shriek);
        fightFlytrapButton.gameObject.SetActive(false);
        waitFlytrapButton.gameObject.SetActive(false);
        fighter.GetComponent<SimpleController>().enabled = true;
        //fighter.GetComponent<CutsceneController>().enabled = false;
        shatter02.SetActive(true);
        phoebefeet.SetActive(true);
        swoop.Play();
        mainCam01.SetActive(false);
        fighterPOV.Priority = 15;
        //paused = false;
       /* if (!fightSongs.isPlaying)
        {
            fightSongs.clip = beatLoop;
            fightSongs.Play();
        }*/

        if (flytrapAnim != null)
        {
            flytrapAnim.Play(animFlytrapName); 
        }
        StartCoroutine(flytrapDie());
    }

    public void FlytrapWait()
    {
        sparkleObject.SetActive(true);
        dialogueTrigger.SetActive(true);
        fightFlytrapButton.gameObject.SetActive(false);
        waitFlytrapButton.gameObject.SetActive(false);
        fighter.GetComponent<SimpleController>().enabled = true;
        shatter02.SetActive(true);
        phoebefeet.SetActive(true);
        swoop.Play();
        mainCam01.SetActive(false);
        fighterPOV.Priority = 15;
        //paused = false;
        /*if (!fightSongs.isPlaying)
        {
            fightSongs.clip = sighLoop;
            fightSongs.Play();
        }*/
      
    }
//-----------------HUSK-------------------//
    public void HuskTrigger()
    {
        paused = true;
        fightHuskButton.gameObject.SetActive(true);
        waitHuskButton.gameObject.SetActive(true);
        Debug.Log("collided");
    }

    public void HuskFight()
    {
        fighterAnim.Play("slash");
        fightSounds.PlayOneShot(slash);
        
        fightSounds.PlayOneShot(shriek);
        fightHuskButton.gameObject.SetActive(false);
        waitHuskButton.gameObject.SetActive(false);
        paused = false;
        if (!fightSongs.isPlaying)
        {
            fightSongs.clip = beatLoop;
            fightSongs.Play();
        }

        if (huskAnim != null)
        {
            huskAnim.Play(animHuskName); 
        }
        StartCoroutine(huskDie());
    }

    public void HuskWait()
    {
        fightHuskButton.gameObject.SetActive(false);
        waitHuskButton.gameObject.SetActive(false);
        paused = false;
        if (!fightSongs.isPlaying)
        {
            fightSongs.clip = sighLoop;
            fightSongs.Play();
        }
      
    }
    IEnumerator flytrapDie()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(flyTrap);
    }
    
    IEnumerator huskDie()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(husk);
    }
}
