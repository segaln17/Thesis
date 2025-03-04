using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPond : MonoBehaviour
{
    public int pondCounter;
    public int goal=18;
    public bool hasHitLimit;
    public bool isStarted = false;
    public AudioSource pondAudio;
    public AudioClip pondCrackSound;
    public GameObject crackedPond;
    public GameObject frozenFish;
    public GameObject standingFish;
   
    
    // Start is called before the first frame update
    void Start()
    {
        pondCounter = 0;
        hasHitLimit = false;
        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pondCounter >= goal && !hasHitLimit && !isStarted)
        {
            StartCoroutine(pondCrack());
        }
        hasHitLimit = false;
    }

    /*private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PondRock"))
        {
            pondCounter++;

            if (pondCounter == goal)
            {
                hasHitLimit = true;
            }
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PondRock"))
        {
            pondCounter++;

            if (pondCounter == goal)
            {
                hasHitLimit = true;
            }
        }
    }


    IEnumerator pondCrack()
    {
        isStarted = true;
        pondAudio.PlayOneShot(pondCrackSound);
        crackedPond.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(4f);
        frozenFish.transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
        crackedPond.SetActive(false);
        yield return new WaitForSeconds(.5f);
        frozenFish.SetActive(false);
        standingFish.SetActive(true);
        Destroy(gameObject);
    }
}
