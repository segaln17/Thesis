using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Yarn.Unity;
using Input = UnityEngine.Windows.Input;

public class TimelineTest : MonoBehaviour
{
    public PlayableDirector timeline;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("timelineGo")]
    public void GoTimeline()
    {
        timeline.Play();
        //Debug.Log("cube");
    }
}
