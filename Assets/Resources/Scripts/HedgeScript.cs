using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgeScript : MonoBehaviour
{
    public Queue<string> noteQueue = new Queue<string>();
    public string goalString;

    public bool isSinging = false;

    public string sungNotes;

    public int numNotesSung;

    public Animator hedge1animator;
    public Animator hedge2animator;
    
    // Start is called before the first frame update
    void Start()
    {
        //pattern written in the UI:
        goalString = "WDAS";
        numNotesSung = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SongScript.instance.sheetActive)
        {
            isSinging = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("hedge");
        if (other.gameObject.CompareTag("Player"))
        {
            if (isSinging)
            {
                if (noteQueue.Count <= 4)
                {
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        //numNotesSung += 1;
                        noteQueue.Enqueue("W");
                        sungNotes += noteQueue.Dequeue();
                        Debug.Log("W");
                        
                    }

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                       //numNotesSung += 1;
                        noteQueue.Enqueue("A");
                        sungNotes += noteQueue.Dequeue();
                        Debug.Log("A");
                        
                    }

                    if (Input.GetKeyDown(KeyCode.D))
                    {
                       // numNotesSung += 1;
                        noteQueue.Enqueue("D");
                        sungNotes += noteQueue.Dequeue();
                        Debug.Log("D");
                    }

                    if (Input.GetKeyDown(KeyCode.S))
                    {
                       // numNotesSung += 1;
                        noteQueue.Enqueue("S");
                        sungNotes += noteQueue.Dequeue();
                        Debug.Log("S");
                    }
                    //Debug.Log(numNotesSung);
                }
                CheckNotes();
                
            }
            
        }
    }

    //Got rid of this to try and streamline it
    /*
    public void QueuetoPhrase()
    {
        while (noteQueue.Count > 0)
        {
            sungNotes += noteQueue.Dequeue();
        }
    }
    */
    
    public void CheckNotes()
    {
        //QueuetoPhrase();
        if (sungNotes == goalString)
        {
            Debug.Log("correct song");
            StartCoroutine("WaitAnimate");
            //play something
        }
    }

    IEnumerator WaitAnimate()
    {
        yield return new WaitForSeconds(1f);
        hedge1animator.Play("hedge1Test");
        hedge2animator.Play("hedge2test");
    }
    //load in goal phrase
    //if keys are pressed, load in the letters
    //compare queue to target phrase
    //if it's the same, play a sound maybe and do an animation of stuff parting

    //THIS DOESN'T WORK:
    private void OnTriggerExit(Collider other)
    {
        numNotesSung = 0;
        noteQueue.Clear();
    }
}
