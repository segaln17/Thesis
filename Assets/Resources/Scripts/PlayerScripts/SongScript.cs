using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    //public static SongScript instance;
    // public GameObject playerSprite;

    //public GameObject song01;
    //public GameObject song02;

    public bool sheetActive;

    //public GameObject hand;
    public GameManager gameManager;

    public Animator songAnim;
    public Animator songSwitch;

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

    //private IEnumerator sheathCoroutine;
    // private IEnumerator switchBeastCoroutine;
    // private IEnumerator switchOpenCoroutine;
    // public GameObject fighter;

    public humRegister state;
    public enum humRegister
    {
        leftCap,
        high,
        mid,
        low,
        rightCap
    }
    
    private void Awake()
    {
        /*
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        */
    }


    // Start is called before the first frame update
    void Start()
    {
        state = humRegister.mid;
        //sheathCoroutine = Sheathing();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentPOV == GameManager.CharacterPOV.Fighter && Input.GetKeyDown(KeyCode.Space))
        {
            sheetActive = !sheetActive;
        }

        if (sheetActive)
        {
            
            songAnim.SetBool("Idle", true);
            songAnim.SetBool("Sheathe", false);
            //playerSprite.SetActive(false);
            //fighter.GetComponent<SimpleController>().enabled = false;
            //fighter.GetComponent<Rigidbody>().isKinematic = true;

            if (inventoryManager.HasItem("Song of Beasts"))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    songSwitch.SetBool("beastsong", true);

                }

                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                   
                    songSwitch.SetBool("beastsong", false);
                }
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

            if (state == humRegister.leftCap)
            {
                state = humRegister.low;
            }

            if (state == humRegister.rightCap)
            {
                state = humRegister.high;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                state++;
         
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                state--;
            }


        }
        else
        {
            songAnim.SetBool("Sheathe", true);
            songAnim.SetBool("Idle", false);
            //fighter.GetComponent<SimpleController>().enabled = true;
            // fighter.GetComponent<Rigidbody>().isKinematic = false;
            //playerSprite.SetActive(true);
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
