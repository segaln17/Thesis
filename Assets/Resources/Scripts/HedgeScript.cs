using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgeScript : MonoBehaviour
{
    public SongScript songScript; 
    
    public List<string> noteQueue = new List<string>();

    public string goalPhrase = "WDAS";
    public bool isSinging = false;
    public bool isinHedge = false;
    

    public Animator hedge1animator;
    //public Animator hedge2animator;
    
    public bool timerActive = false;
    public float hitWindowTime = 0.0f;
    public float hitWindowCap = 0.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            hitWindowTime -= Time.deltaTime;

            //stopping the timer to limit the input
            if (hitWindowTime <= 0)
            {
                StopWindowTimer();
            }
        }

        if (songScript.sheetActive)
        {
            isSinging = true;
        }
        else
        {
            isSinging = false;
        }

        if (isSinging && isinHedge)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                StartWindowTimer();
                noteQueue.Add("W");
                Debug.Log("W");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {   //StartWindowTimer();
                noteQueue.Add("D");
                Debug.Log("D");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                //StartWindowTimer();
                noteQueue.Add("A");
                Debug.Log("A");
                //sungNotes += noteQueue.Dequeue();
                //numNotesSung += 1;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //StartWindowTimer();
                noteQueue.Add("S");
                Debug.Log("S");
                // numNotesSung += 1;
                //sungNotes += noteQueue.Dequeue();
            }
           /* if (noteQueue.Count == 0)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    StartWindowTimer();
                    noteQueue.Add("W");
                    Debug.Log("W");
                }
            }

            if (noteQueue.Count == 1)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {   //StartWindowTimer();
                    noteQueue.Add("D");
                    Debug.Log("D");
                }
            }

            if (noteQueue.Count == 2)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    //StartWindowTimer();
                    noteQueue.Add("A");
                    Debug.Log("A");
                    //sungNotes += noteQueue.Dequeue();
                    //numNotesSung += 1;
                }
            }

            if (noteQueue.Count == 3)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    //StartWindowTimer();
                    noteQueue.Add("S");
                    Debug.Log("S");
                    // numNotesSung += 1;
                    //sungNotes += noteQueue.Dequeue();
                }
            }*/

        }
        CheckNotes();

        if (noteQueue.Count == 4 && ListtoString(noteQueue) != goalPhrase)
        {
            noteQueue = new List<string>();
        }
        if (noteQueue.Count == 4 && noteQueue[3] != "S")
        {
            noteQueue.RemoveAt(3);
            noteQueue.RemoveAt(2);
            noteQueue.RemoveAt(1);
            noteQueue.RemoveAt(0);
        }

        if (noteQueue.Count == 3 && noteQueue[2] != "A")
        {
            noteQueue.RemoveAt(2);
            noteQueue.RemoveAt(1);
            noteQueue.RemoveAt(0);
        }
        
        if (noteQueue.Count == 2 && noteQueue[1] != "D")
        {
            noteQueue.RemoveAt(1);
            noteQueue.RemoveAt(0);
        }
        if (noteQueue.Count == 1 && noteQueue[0] != "W")
        {
            noteQueue.RemoveAt(0);
        }
    }

    private void OnTriggerStay(Collider other)
        {
            //Debug.Log("hedge");
            if (other.gameObject.CompareTag("Player"))
            {
                isinHedge = true;
            }
        }

        public void CheckNotes()
        {
            //ListtoString(noteQueue);
           if (ListtoString(noteQueue) == goalPhrase)
            {
                Debug.Log("correct song");
                StartCoroutine("WaitAnimate");
                //play something
            }
        }

        private string ListtoString(List<string> list)
        {
            string noteResults = "";
            foreach (var noteItem in list)
            {
                noteResults += noteItem.ToString();
            }

            return noteResults;
        }

        IEnumerator WaitAnimate()
        {
            yield return new WaitForSeconds(1f);
            hedge1animator.SetBool("hedgeOpen", true);
            //hedge2animator.Play("hedge2test");
            noteQueue.Clear();
        }
        //load in goal phrase
        //if keys are pressed, load in the letters
        //compare queue to target phrase
        //if it's the same, play a sound maybe and do an animation of stuff parting

      
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isinHedge = false;
                noteQueue.Clear();
            }
            
        }
        
        public void StartWindowTimer()
        {
            hitWindowTime = hitWindowCap;
            timerActive = true;
        }

        public void StopWindowTimer()
        {
            hitWindowTime = 0;
            timerActive = false;
        }
}
