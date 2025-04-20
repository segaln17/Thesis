using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplesong : MonoBehaviour
{
    public AudioSource SongAudio;

    public AudioClip hum01;
    public AudioClip hum02;
    public AudioClip hum03;
    public AudioClip hum04;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //SongAudio.pitch = UnityEngine.Random.Range(.95f, 1f);
            SongAudio.PlayOneShot(hum01);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //SongAudio.pitch = UnityEngine.Random.Range(.95f, 1f);
            SongAudio.PlayOneShot(hum02);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //SongAudio.pitch = UnityEngine.Random.Range(.95f, 1);
            SongAudio.PlayOneShot(hum03);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //SongAudio.pitch = UnityEngine.Random.Range(.95f, 1);
            SongAudio.PlayOneShot(hum04);
        }
    }
}
