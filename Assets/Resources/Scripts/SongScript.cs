using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongScript : MonoBehaviour
{
    public static SongScript instance;
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

    public humRegister state;
    public float deadZoneMax = 1f;
    public float registerCeiling = 5f;
    public enum humRegister
    {
        high,
        mid,
        low
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        state = humRegister.mid;
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
            //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            sheetMusic.SetActive(true);
            fighter.GetComponent<SimpleController>().enabled = false;
            
            
            if(Input.GetAxisRaw("Mouse ScrollWheel") >= deadZoneMax && Input.GetAxisRaw("Mouse ScrollWheel") <= registerCeiling && state == humRegister.mid)
            {
                state = humRegister.high;
            }
            
            if(Input.GetAxisRaw("Mouse ScrollWheel") >= deadZoneMax && Input.GetAxisRaw("Mouse ScrollWheel") <= registerCeiling && state == humRegister.low)
            {
                state = humRegister.mid;
            }
            
            if(Input.GetAxisRaw("Mouse ScrollWheel") <= -deadZoneMax && Input.GetAxisRaw("Mouse ScrollWheel") >= -registerCeiling && state == humRegister.mid)
            {
                state = humRegister.low;

            }
            if(Input.GetAxisRaw("Mouse ScrollWheel") <= -deadZoneMax && Input.GetAxisRaw("Mouse ScrollWheel") >= -registerCeiling && state == humRegister.high)
            {
                state = humRegister.mid;
            }

            if (state == humRegister.mid)
            {
                midRange();
            }
            
            if (state == humRegister.low)
            {
                lowRange();
            }
            
            if (state == humRegister.high)
            {
                highRange();
            }
            
        }
        else
        {
            sheetMusic.SetActive(false);
            fighter.GetComponent<SimpleController>().enabled = true;
        }
    }

    void midRange()
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

    void lowRange()
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

    void highRange()
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
