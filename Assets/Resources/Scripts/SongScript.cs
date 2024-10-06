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
    
    public AudioClip hum05;
    public AudioClip hum06;
    public AudioClip hum07;
    public AudioClip hum08;
    
    public AudioClip hum09;
    public AudioClip hum10;
    public AudioClip hum11;
    public AudioClip hum12;

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

            if(Input.GetAxis("Mouse ScrollWheel") == 0)
            {
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
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    SongAudio.PlayOneShot(hum12);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    SongAudio.PlayOneShot(hum11);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SongAudio.PlayOneShot(hum09);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    SongAudio.PlayOneShot(hum10);
                }
                
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    SongAudio.PlayOneShot(hum05);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    SongAudio.PlayOneShot(hum06);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SongAudio.PlayOneShot(hum08);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    SongAudio.PlayOneShot(hum07);
                }
                
            }
            
        }
        else
        {
            sheetMusic.SetActive(false);
            fighter.GetComponent<SimpleController>().enabled = true;
        }
    }
}
