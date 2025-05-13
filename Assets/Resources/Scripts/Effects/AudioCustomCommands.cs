using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AudioCustomCommands : MonoBehaviour
{
    public AudioSource OverworldMain;
    public AudioSource hubOverride;
    
    public GameObject audioObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [YarnCommand("revealAudio")]
    public void RevealThing()
    {
        audioObject.SetActive(true);
    }

    [YarnCommand("hideAudio")]
    public void HideThing()
    {
        audioObject.SetActive(false);
    }

    [YarnCommand("originalAudioUp")]
    public void OriginalAudioUp()
    {
        if(OverworldMain.volume < 1)
        {
            OverworldMain.volume = 1;
        }

        OverworldMain.Play();
        hubOverride.volume = 0;
    }
}
