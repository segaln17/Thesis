using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startsing : MonoBehaviour
{
    public GameObject songManager;
    //public AudioSource caveAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void songOn()
    {
        songManager.GetComponent<StartScene>().enabled = true;

    }


}
