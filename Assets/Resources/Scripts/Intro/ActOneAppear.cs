using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ActOneAppear : MonoBehaviour
{
    public GameObject act1appear;
    public AudioSource soundEffects;
    public AudioClip introSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(actOneAppear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("playHarp")]
    public void playHarp()
    {
        soundEffects.PlayOneShot(introSound);
    }
    public IEnumerator actOneAppear()
    {
        yield return new WaitForSeconds(35f);
        act1appear.SetActive(true);
        soundEffects.PlayOneShot(introSound);
        yield return new WaitForSeconds(1f);
        StopCoroutine(actOneAppear());
    }
}
