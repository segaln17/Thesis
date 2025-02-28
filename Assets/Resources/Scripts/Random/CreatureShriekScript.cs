using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;


public class CreatureShriekScript : MonoBehaviour
{
    public AudioSource creatureNoiseSource;

    public AudioClip creatureShriek;
    private AudioClip currentClip;
    public float lowRange = 0.4f;
    public float highRange = 1f;

    public Image avatarImage;
    public Sprite avatar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                
                PlayClip(creatureShriek);
            }
        }
    }*/


    [YarnCommand("changeAvatar")]
    public void ChangeAvatar()
    {
        avatarImage.sprite = avatar;
    }
    
    [YarnCommand("playClip")]
    public void talkingClip()
    {
        PlayClip(creatureShriek);
    }

    public void PlayClip(AudioClip clip)
    {
        if (currentClip != clip) //checks if the provided clip is still playing
        {
            creatureNoiseSource.Stop(); //if not, it stops playback and changes the clip
            currentClip = clip;
            creatureNoiseSource.pitch = UnityEngine.Random.Range(lowRange, highRange);
            creatureNoiseSource.PlayOneShot(currentClip);
        }
        else
        {//otherwise, it checks if the src is currently playing the audioclip and plays it if it isn't
            if (!creatureNoiseSource.isPlaying)
            {
                creatureNoiseSource.pitch = UnityEngine.Random.Range(lowRange, highRange);
                creatureNoiseSource.PlayOneShot(currentClip);
            }
        }
    }
}
