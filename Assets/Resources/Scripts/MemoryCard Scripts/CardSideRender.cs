using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSideRender : MonoBehaviour
{
    public Animator cardAnimator;
    public bool isRead = false;
    public Button chooseButton;
    public Button flipButton;

    public AudioSource clickButtonAudio;
    public AudioClip clickButtonClip;
    private AudioClip currentClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPaper()
    {
        cardAnimator.SetBool("Clicked", true);
        flipButton.enabled = false;
        isRead = true;
        chooseButton.gameObject.SetActive(true);
        PlayButtonClip(clickButtonClip);
    }

    public void ClickTarot()
    {
        cardAnimator.SetBool("Clicked", true);
        flipButton.enabled = false;
        isRead = true;
        PlayButtonClip(clickButtonClip);
    }

    public void PlayButtonClip(AudioClip clip)
    {
        if (currentClip != clip) //checks if the provided clip is still playing
        {
            clickButtonAudio.Stop(); //if not, it stops playback and changes the clip
            currentClip = clip;
            //clickButtonAudio.pitch = UnityEngine.Random.Range(lowRange, highRange);
            clickButtonAudio.PlayOneShot(currentClip);
        }
        else
        {//otherwise, it checks if the src is currently playing the audioclip and plays it if it isn't
            if (!clickButtonAudio.isPlaying)
            {
                //creatureNoiseSource.pitch = UnityEngine.Random.Range(lowRange, highRange);
                clickButtonAudio.PlayOneShot(currentClip);
            }
        }
    }
}
