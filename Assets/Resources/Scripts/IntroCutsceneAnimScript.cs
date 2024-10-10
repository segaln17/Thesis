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
    
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        fightButton.gameObject.SetActive(false);
        waitButton.gameObject.SetActive(false);
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

    }

    public void Fight()
    {
        fighterAnim.Play("slash");
        fightSounds.PlayOneShot(slash);
        monsterAnim.Play("flytrapdie");//FILL IN fightMove.name with the actual animation clip name
        fightSounds.PlayOneShot(shriek);
        fightButton.gameObject.SetActive(false);
        waitButton.gameObject.SetActive(false);
        paused = false;
    }

    public void Wait()
    {
        fightButton.gameObject.SetActive(false);
        waitButton.gameObject.SetActive(false);
        paused = false;
        //StartCoroutine(WaitMove());
        //fighterAnim.Play(waitMove.name); //FILL IN WITH ACTUAL NAME
    }

    /*IEnumerator WaitMove()
    {
        //yield return new WaitForSeconds(5f);
    }*/
}
