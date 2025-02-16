using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryManager : MonoBehaviour
{
    public GameObject memoryGame;
    public GameObject scrapbookText;
    public Image scrapbook;

    public Sprite bookSpriteClosed;
    public Sprite bookSpriteOpen;

    //---Bools---
    public bool inMemoryGame;
    public bool dreamerCollected=false;

    public GameObject dreamerCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (dreamerCollider.CompareTag("Dreamer"))
        {
            if (inMemoryGame && Input.GetKeyDown(KeyCode.Space))
            {
                CloseScrapbook();
                dreamerCollider.SetActive(false);
                dreamerCollected = true;
            }
        }
        
    }

    public void CloseScrapbook()
    {
        StartCoroutine(BookClose());
        
    }

    IEnumerator BookClose()
    {
        yield return new WaitForSeconds(1f);
        //sprite change to book closed
        scrapbook.sprite = bookSpriteClosed;
        scrapbookText.SetActive(false);
        yield return new WaitForSeconds(3f);
        scrapbookText.SetActive(true);
        memoryGame.SetActive(false);    
    }

}

