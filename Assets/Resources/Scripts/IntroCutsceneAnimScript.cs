using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutsceneAnimScript : MonoBehaviour
{
    public Animator fighterAnim;
    public Animator monsterAnim;

    //public AnimationClip waitMove;
    //public AnimationClip fightMove;
    //public AnimationClip dieMove;

    public Button fightButton;
    public Button waitButton;

    public AudioSource fightSounds;
    public AudioClip shriek;
    public AudioClip slash;

    private bool paused;
    Collider m_Collider;
    public string animName;

    public AudioSource fightSongs;
    public AudioClip beatLoop;
    public AudioClip sighLoop;
    
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        fightButton.gameObject.SetActive(false);
        waitButton.gameObject.SetActive(false);
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    { //put this here, not sure yet if it works but will with testing
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        fightButton.gameObject.SetActive(true);
        waitButton.gameObject.SetActive(true);
        paused = true;
        Debug.Log(Time.timeScale);

    }

    public void Fight()
    {
        fighterAnim.Play("slash");
        fightSounds.PlayOneShot(slash);
        monsterAnim.Play(animName);
        ;//FILL IN fightMove.name with the actual animation clip name
        /*if (gameObject.tag == "flytrap")
        {
            monsterAnim.Play("flytrapdie");
            Debug.Log("flytrapanim");
        }

        if (gameObject.tag == "husk")
        {
            monsterAnim.Play("creaturedie");
            Debug.Log("huskanim");
        }*/
        fightSounds.PlayOneShot(shriek);
        fightButton.gameObject.SetActive(false);
        waitButton.gameObject.SetActive(false);
        paused = false;
        if (!fightSongs.isPlaying)
        {
            fightSongs.clip = beatLoop;
            fightSongs.Play();
        }
        StartCoroutine(Die());
    }

    public void Wait()
    {
        fightButton.gameObject.SetActive(false);
        waitButton.gameObject.SetActive(false);
        paused = false;
        m_Collider.enabled = false;
        if (!fightSongs.isPlaying)
        {
            fightSongs.clip = sighLoop;
            fightSongs.Play();
        }
        //StartCoroutine(WaitMove());
        //fighterAnim.Play(waitMove.name); //FILL IN WITH ACTUAL NAME
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
