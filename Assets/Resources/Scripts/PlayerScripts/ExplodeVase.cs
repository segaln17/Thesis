using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeVase : MonoBehaviour
{
    public GameObject audioManager;
    public GameObject vaseTogether;
    public GameObject vaseBroken;

    public AudioClip potAlert;
    public AudioSource potBreak;
    public AudioClip potShot;
    private bool hasplayed = false;

    public bool singtimerActive = false;
    public float singhitWindowTime = 0.0f;
    public float singhitWindowCap = 10f;

    // Start is called before the first frame update
    void Start()
    {
        vaseTogether.SetActive(true);
        vaseBroken.SetActive(false);
    }

    private void Update()
    {
        if (singtimerActive)
        {
            singhitWindowTime -= Time.deltaTime;

            //stopping the timer to limit the input
            if (singhitWindowTime <= 0)
            {
                StopSingTimer();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!potBreak.isPlaying && !singtimerActive)
            {
                potBreak.PlayOneShot(potAlert);
                Debug.Log("Singback");
                StartSingTimer();
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
       
        //put timer here
        if (other.gameObject.CompareTag("Player"))
        {
            if (audioManager.GetComponent<SongScript>().sheetActive == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    vaseTogether.SetActive(false);
                    vaseBroken.SetActive(true);
                    
                    if (!potBreak.isPlaying && !hasplayed)
                    {
                        potBreak.pitch = UnityEngine.Random.Range(0.85f, 1);
                        potBreak.PlayOneShot(potShot);
                    }
                    
                    Destroy(gameObject);
                }
            }
        }
      
    }

    public void StartSingTimer()
    {
        singhitWindowTime = singhitWindowCap;
        singtimerActive = true;
    }

    public void StopSingTimer()
    {
        singhitWindowTime = 0;
        singtimerActive = false;
    }
}
