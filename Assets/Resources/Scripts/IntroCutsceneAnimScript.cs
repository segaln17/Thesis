using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutsceneAnimScript : MonoBehaviour
{
    public Animator fighterAnim;
    public Animator monsterAnim;

    public GameObject fighter;
    
    //public AnimationClip waitMove;
    //public AnimationClip fightMove;
    //public AnimationClip dieMove;

    public Button fightButton;
    public Button waitButton;

    public AudioSource fightSounds;
    public AudioClip shriek;
    public AudioClip slash;

    public bool paused;
    Collider m_Collider;
    public string animName;

    public AudioSource fightSongs;
    public AudioClip beatLoop;
    public AudioClip sighLoop;
    
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Time.timeScale = 1;
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
            fighter.GetComponent<CutsceneController>().enabled = false;
            fighter.GetComponent<Rigidbody>().isKinematic = true;
            fighter.GetComponent<Animator>().enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            fighter.GetComponent<CutsceneController>().enabled = true;
            fighter.GetComponent<Rigidbody>().isKinematic = false;
            fighter.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        paused = true;
        fightButton.gameObject.SetActive(true);
        waitButton.gameObject.SetActive(true);
        m_Collider.enabled = false;
        Debug.Log("collided");

    }

    public void Fight()
    {
        fighterAnim.Play("slash");
        fightSounds.PlayOneShot(slash);
        monsterAnim.Play(animName);
        
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
      
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
