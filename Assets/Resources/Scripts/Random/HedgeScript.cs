using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Playables;
using Yarn.Unity;

public class HedgeScript : MonoBehaviour
{
    public YarnCutsceneManager yarnCutsceneManager;

    public GameObject audioManager;

    public List<string> noteQueue = new List<string>();

    [Header("Garden Songs")]
    public string goalPhrase = "WDAS";
    public bool isSinging = false;
    public bool isinHedge = false;
    public bool inOpening = false;

    public bool isGarden = false;
    public bool isOutsideGarden = false;
    public bool isMoon = false;
    //public GameObject gardenEnter;

    [Header("Trees Sing")] 
    public AudioSource treeSing;
    public AudioClip treehum01;
    public AudioClip singAlert;
    

    public Animator hedge1animator;
    //public Animator hedge2animator;

    public Animator doorsAnimator;

    public PlayableDirector gardenTimeline;
    
    public bool timerActive = false;
    public float hitWindowTime = 0.0f;
    public float hitWindowCap = 0.5f;

    public bool singtimerActive = false;
    public float singhitWindowTime = 0.0f;
    public float singhitWindowCap = 10f;

    //yarn things
    public string nodeToCall;
    
    //room
    public GameObject room;
    
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
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

        if (singtimerActive)
        {
            singhitWindowTime -= Time.deltaTime;

            //stopping the timer to limit the input
            if (singhitWindowTime <= 0)
            {
                StopSingTimer();
            }
        }

        if (audioManager.GetComponent<SongScript>().sheetActive)
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

            if (inOpening)
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
        //TODO: CHANGE TO SDAWD
        if (isGarden)
        {
            if (noteQueue.Count == 5 && ListtoString(noteQueue) != goalPhrase)
            {
                noteQueue = new List<string>();
            }
            if (noteQueue.Count == 5 && noteQueue[4] != "D")
            {
                noteQueue.RemoveAt(4);
                noteQueue.RemoveAt(3);
                noteQueue.RemoveAt(2);
                noteQueue.RemoveAt(1);
                noteQueue.RemoveAt(0);
            }
            if (noteQueue.Count == 4 && noteQueue[3] != "W")
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
            if (noteQueue.Count == 1 && noteQueue[0] != "S")
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!treeSing.isPlaying && !singtimerActive)
            {
               treeSing.PlayOneShot(singAlert);
                Debug.Log("Singback");
                StartSingTimer();
            }

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
                    //audioManager.GetComponent<SongScript>().sheetActive = false;
                    isSinging = false;
                    doorsAnimator.SetBool("doorsopengarden", true);
                    StartCoroutine("WaitTimeline");
                }

                if (isOutsideGarden)
                {
                    StartCoroutine("TreeSing");
                    StartCoroutine("WaitAnimate");
                    
                    
                    if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
                    {
                        FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
                        //room.transform.rotation.eulerAngles = 
                    }
                    
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
            //audioManager.GetComponent<SongScript>().sheetActive = false;
            isSinging = false;
            yield return new WaitForSeconds(1f);
            //gardenEnter.SetActive(true);
            //hedge2animator.Play("hedge2test");
            noteQueue.Clear();
            yield return new WaitForSeconds(2f);
            this.gameObject.SetActive(false);
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
            yield return new WaitForSeconds(1f);
            treeSing.PlayOneShot(treehum01);
           
        }

    public void StartSingTimer()
    {
        singhitWindowTime = singhitWindowCap;
        singtimerActive = true;
    }

    public void StopSingTimer()
    {
        singhitWindowTime = 0;
        singtimerActive = false;
    }
}
