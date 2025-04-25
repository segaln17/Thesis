using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class RevealObjectCustomCommands : MonoBehaviour
{
    public GameObject thing;
    // Start is called before the first frame update
    void Start()
    {
        thing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("revealThing")]
    public void RevealThing()
    {
        thing.SetActive(true);
    }

    [YarnCommand("hideThing")]
    public void HideThing()
    {
        thing.SetActive(false);
    }
}
