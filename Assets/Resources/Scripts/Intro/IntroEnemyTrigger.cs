using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class IntroEnemyTrigger : MonoBehaviour
{
    public GameObject thisGameObject;
    public GameObject player;
    public GameObject enemyManager;
    public Collider thisCollider;
    public GameObject shatter;
    public GameObject phoebebattlesprite;
    public CinemachineVirtualCamera firstperson;
    public GameObject sprite;
    public AudioSource battleSound;
    public AudioSource introMain;
    public AudioSource battleOverride;
    public GameObject phoebeShadowsprite;

    // Start is called before the first frame update
    private void Start()
    {
        enemyManager.GetComponent<IntroCutsceneAnimScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            thisCollider.enabled = false;
            
            if (thisGameObject.tag == "flytrap")
            {
                shatter.SetActive(true);
                sprite.SetActive(false);
                phoebeShadowsprite.SetActive(false);
                firstperson.Priority = 12;
                phoebebattlesprite.SetActive(true);
                player.GetComponent<CutsceneController>().enabled = false;
                battleSound.Play();
                //player.GetComponent<SimpleController>().enabled = true;
                enemyManager.GetComponent<IntroCutsceneAnimScript>().FlyTrapTrigger();

                StartCoroutine(FadeOutIntro(introMain, 1f));
                battleOverride.Play();
            }
           
        }
    }

    public IEnumerator FadeOutIntro(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        //float hubStartVolume = 1f;


        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        /*while (battleOverride.volume < 1)
        {
            battleOverride.volume += 1 * Time.deltaTime / FadeTime;
            yield return null;
        }*/

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
