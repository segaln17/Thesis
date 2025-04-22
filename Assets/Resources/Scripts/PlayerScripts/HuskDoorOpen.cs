using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuskDoorOpen : MonoBehaviour
{
    //public GameObject instructions;

    public Animator doorAnim;

    public SongScript songScript;

    public List<string> noteQueue = new List<string>();

    [Header("Portal Song")]
    public string goalPhrase = "WDAS";
    public bool isSinging = false;
    public bool isinCollider = false;
    public bool isOutsideCollider = false;

    public bool timerActive = false;
    public float hitWindowTime = 0.0f;
    public float hitWindowCap = 0.5f;
    
    //sound for song script collider:
    public AudioSource doorSound;

    public AudioClip singAlert;
    // Start is called before the first frame update
    void Start()
    {
        //portalPlane.SetActive(false);
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


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isinCollider = true;
            //timer here
            doorSound.PlayOneShot(singAlert);
        }
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
        doorAnim.SetBool("huskdooropen", true);
        songScript.sheetActive = false;
        isSinging = false;
        yield return new WaitForSeconds(1f);
        noteQueue.Clear();

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
