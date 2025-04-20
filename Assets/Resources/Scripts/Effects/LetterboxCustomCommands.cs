using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LetterboxCustomCommands : MonoBehaviour
{
    public Animator letterboxAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("letterboxIn")]
    public void LetterboxAppear()
    {
        letterboxAnimator.SetBool("LetterboxGo", true);
        letterboxAnimator.SetBool("LetterboxAway", false);
    }

    [YarnCommand ("letterboxOut")]
    public void LetterboxOut()
    {
        letterboxAnimator.SetBool("LetterboxGo", false);
        letterboxAnimator.SetBool("LetterboxAway", true);
    }
}
