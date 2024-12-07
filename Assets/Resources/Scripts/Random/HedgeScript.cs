using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Yarn.Unity;

public class HedgeScript : MonoBehaviour
{
    public YarnCutsceneManager yarnCutsceneManager;
    
    public SongScript songScript; 
    
    public List<string> noteQueue = new List<string>();

    [Header("Garden Songs")]
    public string goalPhrase = "WDAS";
    public bool isSinging = false;
    public bool isinHedge = false;

    public bool isGarden = false;
    public bool isOutsideGarden = false;
    public bool isMoon = false;
    public GameObject gardenEnter;

    [Header("Trees Sing")] 
    public AudioSource treeSing;
    public AudioClip treehum01;
    public AudioClip treehum02;
    public AudioClip treehum03;
    public AudioClip treehum04;
    

    public Animator hedge1animator;
    //public Animator hedge2animator;

    public Animator doorsAnimator;

    public PlayableDirector gardenTimeline;
    
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

        }
        CheckNotes();

        if (isOutsideGarden)
        {
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

        //SONG OF BEASTS: WDADDAWD
        if (isGarden)
        {
            if (noteQueue.Count == 8 && ListtoString(noteQueue) != goalPhrase)
            {
                noteQueue = new List<string>();
            }
            if (noteQueue.Count == 8 && noteQueue[7] != "D")
            {
                noteQueue.RemoveAt(7);
                noteQueue.RemoveAt(6);
                noteQueue.RemoveAt(5);
                noteQueue.RemoveAt(4);
                noteQueue.RemoveAt(3);
                noteQueue.RemoveAt(2);
                noteQueue.RemoveAt(1);
                noteQueue.RemoveAt(0);
            }
            if (noteQueue.Count == 7 && noteQueue[6] != "W")
            {
                noteQueue.RemoveAt(6);
                noteQueue.RemoveAt(5);
                noteQueue.RemoveAt(4);
                noteQueue.RemoveAt(3);
                noteQueue.RemoveAt(2);
                noteQueue.RemoveAt(1);
                noteQueue.RemoveAt(0);
            }
            if (noteQueue.Count == 6 && noteQueue[5] != "A")
            {
                noteQueue.RemoveAt(5);
                noteQueue.RemoveAt(4);
                noteQueue.RemoveAt(3);
                noteQueue.RemoveAt(2);
                noteQueue.RemoveAt(1);
                noteQueue.RemoveAt(0);
            }
            if (noteQueue.Count == 5 && noteQueue[4] != "D")
            {
                noteQueue.RemoveAt(4);
                noteQueue.RemoveAt(3);
                noteQueue.RemoveAt(2);
                noteQueue.RemoveAt(1);
                noteQueue.RemoveAt(0);
            }
            if (noteQueue.Count == 4 && noteQueue[3] != "D")
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
                if (!isGarden && !isMoon)
                {
                    StartCoroutine("WaitAnimate");
                    //play something
                }

                if (isGarden)
                {
                    songScript.sheetActive = false;
                    isSinging = false;
                    doorsAnimator.SetBool("doorsopengarden", true);
                    StartCoroutine("WaitTimeline");
                }

                if (isOutsideGarden)
                {
                    StartCoroutine("TreeSing");
                    StartCoroutine("WaitAnimate");
                }
                
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
            songScript.sheetActive = false;
            isSinging = false;
            yield return new WaitForSeconds(1f);
            gardenEnter.SetActive(true);
            //hedge2animator.Play("hedge2test");
            noteQueue.Clear();
        }
        //load in goal phrase
        //if keys are pressed, load in the letters
        //compare queue to target phrase
        //if it's the same, play a sound maybe and do an animation of stuff parting

        IEnumerator WaitTimeline()
        {
            Debug.Log("garden thing");
            //yarnCutsceneManager.GardenCutscene();
            yield return new WaitForSeconds(1f);
            gardenTimeline.Play();
            noteQueue.Clear();
        }

      
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
        
        [YarnCommand("setGardenSongBool")]
        public void SetGardenBool()
        {
            isGarden = true;
            isOutsideGarden = false;
            isMoon = false;
        }

        [YarnCommand("setMoonSongBool")]
        public void SetMoonSongBool()
        {
            isGarden = false;
            isOutsideGarden = false;
            isMoon = true;
        }

        IEnumerator TreeSing()
        {
            yield return new WaitForSeconds(2.5f);
            treeSing.PlayOneShot(treehum01);
            yield return new WaitForSeconds(.75f); 
            treeSing.PlayOneShot(treehum02);
            yield return new WaitForSeconds(2f);
            treeSing.PlayOneShot(treehum03);
            yield return new WaitForSeconds(2f);
            treeSing.PlayOneShot(treehum04);
            yield return new WaitForSeconds(2f);
        }
}
