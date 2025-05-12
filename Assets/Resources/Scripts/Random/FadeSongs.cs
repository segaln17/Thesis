using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FadeSongs : MonoBehaviour
{
    public AudioSource OverworldMain;
    public AudioSource hubOverride;


    // Start is called before the first frame update
    void Start()
    {
        hubOverride.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Phoebe") || other.gameObject.CompareTag("Fen"))
        {
          
          StartCoroutine(FadeOut(OverworldMain, 2f));
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Phoebe") || other.gameObject.CompareTag("Fen"))
        {
            if(OverworldMain.volume < 1)
            {
                OverworldMain.volume = 1;
            }

            OverworldMain.Play();
            hubOverride.volume = 0;
        }
        
    }


    [YarnCommand ("fadeAudio")]
    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        //float hubStartVolume = 1f;
        

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        while (hubOverride.volume < 1)
        {
            hubOverride.volume += 1 * Time.deltaTime / FadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
