using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryManager : MonoBehaviour
{
    [Header ("Main Objects")]
    public GameObject memoryGame;
    public GameObject scrapbookTextpg1;
    public GameObject scrapbookTextpg2;
    public GameObject existingTextpg1;
    public GameObject existingTextpg2;
    public GameObject eInteract;
    public Image scrapbook;

    public Sprite bookSpriteClosed;
    public Sprite bookSpriteOpen;
    public GameObject scrapBookObj;

    //---Bools---
    [Header("Main Bools")]
    public bool inMemoryGame;
    public bool dreamerCollected=false;
    public bool archaeCollected = false;

    [Header("Dreamer Variables")]
    public MemoryActivation dreamActivation;
    public GameObject dreamerCollider;

    [Header("Archaeo Variables")]
    public MemoryActivation archActivation;
    public GameObject archaeCollider;
    

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        if (dreamActivation.colliderDreamerInside)
        {
            if (inMemoryGame && Input.GetKeyDown(KeyCode.E))
            {
                CloseScrapbook();
                dreamerCollider.SetActive(false);
                dreamerCollected = true;
            }
        }

        if (archActivation.colliderArchaelogistInside)
        {
            if (inMemoryGame && Input.GetKeyDown(KeyCode.E))
            {
                CloseScrapbook();
                archaeCollider.SetActive(false);
                archaeCollected = true;
            }
        }
        
    }

    public void CloseScrapbook()
    {
        //adding this and seeing if it does anything
        StopAllCoroutines();
        
        StartCoroutine(BookClose());
        
    }

    IEnumerator BookClose()
    {
        yield return new WaitForSeconds(1f);
        //sprite change to book closed
        scrapbook.sprite = bookSpriteClosed;
        scrapbookTextpg1.SetActive(false);
        scrapbookTextpg2.SetActive(false);
        existingTextpg1.SetActive(false);
        existingTextpg2.SetActive(false);
        eInteract.SetActive(false);
        yield return new WaitForSeconds(3f);
        memoryGame.SetActive(false);
        yield return new WaitForSeconds(3f);
        scrapbook.sprite = bookSpriteOpen;
        scrapBookObj.SetActive(false);

    }

}

