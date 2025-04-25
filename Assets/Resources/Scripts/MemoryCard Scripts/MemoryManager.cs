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

    public Image archscrapbook;
    public Sprite archbookSpriteClosed;
    public Sprite archbookSpriteOpen;
    public GameObject archscrapBookObj;
    public GameObject existingTextpg1Arch;
    public GameObject existingTextpg2Arch;

    public GameObject DivinerObj;
    public GameObject teleportTransform;

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
    public bool teleportedToTower;
    

   
    // Start is called before the first frame update
    void Start()
    {
        teleportedToTower=false;
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
                CloseArchScrapbook();
                archaeCollider.SetActive(false);
                archaeCollected = true;
            }
        }

        if (archaeCollected && dreamerCollected && !teleportedToTower)
        {
            StartCoroutine(TeleporttoTower());
        }
        
    }

    public void CloseScrapbook()
    {
        //adding this and seeing if it does anything
        //StopAllCoroutines();
        
        StartCoroutine(BookClose());
        
    }

    public void CloseArchScrapbook()
    {
        //adding this and seeing if it does anything
        //StopAllCoroutines();

        StartCoroutine(ArchBookClose());

    }

    IEnumerator BookClose()
    {
        yield return new WaitForSeconds(1f);
        //sprite change to book closed
        
        scrapbookTextpg1.SetActive(false);
        scrapbookTextpg2.SetActive(false);
        existingTextpg1.SetActive(false);
        existingTextpg2.SetActive(false);
        existingTextpg1Arch.SetActive(false);
        existingTextpg2Arch.SetActive(false);
        eInteract.SetActive(false);
        scrapbook.sprite = bookSpriteClosed;
        yield return new WaitForSeconds(3f);
        memoryGame.SetActive(false);
        yield return new WaitForSeconds(3f);
        scrapbook.sprite = bookSpriteOpen;
        scrapBookObj.SetActive(false);

    }

    IEnumerator ArchBookClose()
    {
        yield return new WaitForSeconds(1f);
        //sprite change to book closed
        scrapbookTextpg1.SetActive(false);
        scrapbookTextpg2.SetActive(false);
        existingTextpg1Arch.SetActive(false);
        existingTextpg2Arch.SetActive(false);
        eInteract.SetActive(false);
        archscrapbook.sprite = bookSpriteClosed;
        yield return new WaitForSeconds(3f);
        memoryGame.SetActive(false);
        yield return new WaitForSeconds(3f);
        archscrapbook.sprite = bookSpriteOpen;
        archscrapBookObj.SetActive(false);

    }

    IEnumerator TeleporttoTower()
    {
        yield return new WaitForSeconds(6f);
        DivinerObj.transform.position = teleportTransform.transform.position;
        teleportedToTower = true;

    }

}

