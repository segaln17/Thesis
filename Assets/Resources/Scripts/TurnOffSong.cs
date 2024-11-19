using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSong : MonoBehaviour
{
    public GameObject sheetMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sheetOff()
    {
        sheetMusic.SetActive(false);
    }
}
