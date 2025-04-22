using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class RookeryActivate : MonoBehaviour
{
    public PaintingSceneManager paintSceneManager;
    
    public CinemachineVirtualCamera rookeryCam;
    public CinemachineVirtualCamera firstPerson;
    public CinemachineVirtualCamera firstPersonDiviner;

    public GameObject Player;
    public GameObject PlayerDiviner;

    public GameObject CyanoManager;

    public Button cyanoonbutton;
    
    //singing stuff:
    public SongScript songScript;
    public List<string> noteQueue = new List<string>();
    
    public string goalPhrase = "WDAS";
    public bool isSinging = false;
    public bool isinCollider = false;
    public bool isOutsideCollider = false;
    
    public bool singtimerActive = false;
    public float singhitWindowTime = 0.0f;
    public float singhitWindowCap = 10f;
    
    public bool timerActive = false;
    public float hitWindowTime = 0.0f;
    public float hitWindowCap = 0.5f;
    
    public AudioSource doorSound;

    public AudioClip singAlert;

    public string nodeToCall;
    // Start is called before the first frame update
    void Start()
    {
        cyanoonbutton.gameObject.SetActive(false);
        CyanoManager.SetActive(false);
        
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

        if (songScript.sheetActive)
        {
            isSinging = true;
        }
        else
        {
            isSinging = false;
        }

        if (isSinging && isinCollider)
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

        CheckNotes();

        if (isOutsideCollider)
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
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Phoebe"))
        {
            if (!doorSound.isPlaying && !singtimerActive)
            {
                doorSound.PlayOneShot(singAlert);
                Debug.Log("Singback");
                StartSingTimer();
            }
            //cyanoonbutton.gameObject.SetActive(true); 
        }
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isinCollider = true;
        
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    { 
        cyanoonbutton.gameObject.SetActive(false); 
    }
    */

    public void GotoCyanotype()
    {
        rookeryCam.Priority = 12;
        firstPerson.Priority = 1;
        CyanoManager.SetActive(true);
        //.GetComponent<PaintingSceneManager>().state = PaintingSceneManager.paintingState.newsheet;
        Player.SetActive(false);
        cyanoonbutton.gameObject.SetActive(false);
        if (FindObjectOfType<DialogueRunner>().IsDialogueRunning == false)
        {
            FindObjectOfType<DialogueRunner>().StartDialogue(nodeToCall);
        }
        //firstPersonDiviner.gameObject.SetActive(true);
        paintSceneManager.state = PaintingSceneManager.paintingState.newsheet;
    }

    public void CheckNotes()
    {
        if (ListtoString(noteQueue) == goalPhrase)
        {
            //plane is active
            StartCoroutine("WaitActivate");
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isinCollider = false;
            noteQueue.Clear();
        }

    }

    IEnumerator WaitActivate()
    {
        yield return new WaitForSeconds(1f);
        songScript.sheetActive = false;
        isSinging = false;
        yield return new WaitForSeconds(1f);
        noteQueue.Clear();
        yield return new WaitForSeconds(2f);
        GotoCyanotype();
        //node to call: SheetTaking
        //do we want this line? If it happens we can't restart the cyanotypes
        //this.gameObject.SetActive(false);

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
