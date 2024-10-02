using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongScript : MonoBehaviour
{
    public GameObject sheetMusic;

    public bool sheetActive;

    public AudioSource SongAudio;

    public AudioClip hum01;
    public AudioClip hum02;
    public AudioClip hum03;
    public AudioClip hum04;

    public GameObject fighter;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sheetActive = !sheetActive;
        }

        if (sheetActive)
        {
            sheetMusic.SetActive(true);
            fighter.GetComponent<SimpleController>().enabled = false;

            if (Input.GetKeyDown(KeyCode.W))
            {
                SongAudio.PlayOneShot(hum01);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                SongAudio.PlayOneShot(hum02);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                SongAudio.PlayOneShot(hum03);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                SongAudio.PlayOneShot(hum04);
            }
        }
        else
        {
            sheetMusic.SetActive(false);
            fighter.GetComponent<SimpleController>().enabled = true;
        }
    }
}
