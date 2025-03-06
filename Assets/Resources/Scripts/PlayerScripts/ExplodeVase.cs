using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeVase : MonoBehaviour
{
    public GameObject audioManager;
    public GameObject vaseTogether;
    public GameObject vaseBroken;

    // Start is called before the first frame update
    void Start()
    {
        vaseTogether.SetActive(true);
        vaseBroken.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (audioManager.GetComponent<SongScript>().sheetActive == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    vaseTogether.SetActive(false);
                    vaseBroken.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
      
    }
}
