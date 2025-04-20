using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public List<string> noteQueue = new List<string>();

    [Header("Portal Song")]
    public string goalPhrase = "WDAS";
    public bool isSinging = false;
    public bool isinCollider = false;
    public bool isOutsideCollider = false;

    public bool timerActive = false;
    public float hitWindowTime = 0.0f;
    public float hitWindowCap = 0.5f;


    [Header("StartScene")]
    public GameObject tunnelAppear;
    public GameObject instructions;
    public Animator rightHand;

    
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
        

        CheckNotes();

   
    }


    public void CheckNotes()
    {
        if (ListtoString(noteQueue) == goalPhrase)
        {
            Debug.Log("startnextscene");
            //plane is active
            StartCoroutine("WaitActivateStart");
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

    IEnumerator WaitActivateStart()
    {
        instructions.SetActive(false);
        yield return new WaitForSeconds(1f);
        rightHand.Play("righthandfade");
        tunnelAppear.SetActive(true);
        yield return new WaitForSeconds(1f);
        noteQueue.Clear();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


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

