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

    // Start is called before the first frame update
    void Start()
    {
        vaseTogether.SetActive(true);
        vaseBroken.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        potBreak.PlayOneShot(potAlert);
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
}
