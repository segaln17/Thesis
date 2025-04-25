using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Yarn.Unity;

public class MemoryCardChoose : MonoBehaviour
{
    
    //card side script:
    public CardSideRender cardFlipper1;
    
    //button for existing cards:
    public Button existingCard01;
    public Button existingCard02;
    
    //text for existing cards:
    public TextMeshProUGUI existingText01;
    public TextMeshProUGUI existingText02;
    
    //memory text for each card:
    public TextMeshProUGUI card01Text;
    public TextMeshProUGUI card02Text;
    
    //text in tea swirl:
    public TextMeshProUGUI swirlText;

    //animators for page fade
    public Animator page1;
    public Animator page2;
    public GameObject page01text;
    public GameObject page02text;
    
    //button for new card:
    public Button newCard;
    
    //button for memory card/tea swirl:
    public Button memoryCard;
    
    //text for memory card that will change depending on what is combined:
    public TextMeshProUGUI memoryText;
    //second page
    public TextMeshProUGUI memoryText2;
    
    //what card is chosen:
    private bool isChosen;
    private Button chosenCard;
    
    //what card is forgotten/fades:
    private Button forgottenCard;
    private bool isForgotten;
    
    //if a memory has been revealed
    public bool revealed = false;
    
    //position where chosen card should go:
    //public GameObject chosenCardPos;
    
    //scrapbook:
    public GameObject scrapbook;
    public ScrapbookSave scrapbookScript;


    public string tarotFragment01;
    public string tarotFragment02;
    /*
    //strings that are text for each card set:
    public string dreamerFragment01;
    public string dreamerFragment02;

    public string archaeFragment01;
    public string archaeFragment02;
    */

    public MemoryActivation memoryActivationScript;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //memory card should be inactive
        memoryCard.gameObject.SetActive(false);
        scrapbook.SetActive(false);
        
        //the other cards should probably start inactive too and something in the scene should set them active when this minigame happens
        //but for testing purposes i'm starting with them active here
    }

    // Update is called once per frame
    void Update()
    {
        existingText01.text = tarotFragment01;
        existingText02.text = tarotFragment02;
        /*
        if (memoryActivationScript.gameObject.CompareTag("Archaeologist"))
        {
            existingText01.text = archaeFragment01;
            existingText02.text = archaeFragment02;
        }

        if (memoryActivationScript.gameObject.CompareTag("Dreamer"))
        {
            existingText01.text = dreamerFragment01;
            existingText02.text = dreamerFragment02;
        }
        */
        /*
        if (cardFlipper1.gameObject.CompareTag("card1") && cardFlipper1.isRead == true)
        {
            Choose01();
        }
        if (cardFlipper1.gameObject.CompareTag("card2") && cardFlipper1.isRead == true)
        {
            Choose02();
        }
        */
       
        //ideal plan:
        //click the button once to flip the card
        //if you click that same button again, it chooses that card and then the choose process happens
    }

    public void Choose01()
    {
        isChosen = true;
        chosenCard = existingCard01;
        forgottenCard = existingCard02;
        memoryText.text = card01Text.text;
        swirlText.text = memoryText.text;
        Debug.Log("memory1");
        //StopAllCoroutines();
        StartCoroutine("StartForget");
        RevealMemory();
    }

    public void Choose02()
    {
        isChosen = true;
        chosenCard = existingCard02;
        forgottenCard = existingCard01;
        memoryText.text = card02Text.text;
        swirlText.text = memoryText.text;
        Debug.Log("memory2");
        //StopAllCoroutines();
        StartCoroutine("StartForget");
        
        RevealMemory();
    }

    IEnumerator StartForget()
    {
        yield return new WaitForSeconds(1f);
        forgottenCard.animator.SetBool("NotChosen", true);
        Debug.Log("forgetting");
        yield return new WaitForSeconds(3f);
        //play animation of card fading away? or just set it inactive?
        forgottenCard.gameObject.SetActive(false);
        StopCoroutine(StartForget());
        
    }

    public void RevealMemory()
    {
        //tarot card away
        newCard.gameObject.SetActive(false);
        //card you picked away
        chosenCard.gameObject.SetActive(false);
        //swirl on
        memoryCard.gameObject.SetActive(true);
        swirlText.gameObject.SetActive(true);
        Debug.Log(memoryText.text);
        revealed = true;
        //scrapbookScript.memory.text += "/n" + memoryText.text;
        scrapbookScript.memory.text = swirlText.text;
        memoryText.gameObject.SetActive(true);
        /*
        if (scrapbookScript.MemoryList.Count <3)
        {
            scrapbookScript.MemoryList.Add(memoryText);
            //return;
            
            if (scrapbookScript.MemoryList.Count == 1)
            {
                scrapbookScript.memory.text += "/n" + memoryText.text;
            }
            
        }
        else if (scrapbookScript.MemoryList.Count >= 3)
        {
            scrapbookScript.MemoryList.RemoveAt(0);
            scrapbookScript.MemoryList.Add(memoryText);
        }

        //if count is less than 3:
        if (scrapbookScript.MemoryList.Count ==1)
        {
            //why is it adding it more than once here:
            //scrapbookScript.memory.text += swirlText.text + "\n";
            scrapbookScript.memory.text = swirlText.text;
            
            //memoryText.gameObject.SetActive(false);
            memoryText.gameObject.SetActive(true);
        }
        else if (scrapbookScript.MemoryList.Count ==2)
        {
            //why is it adding it more than once here:
            scrapbookScript.memory.text = memoryText2.text + "\n";
            //memoryText.gameObject.SetActive(false);
            memoryText.gameObject.SetActive(true);
        }
        */
        //else if count is 3:
        //add it to the second memorytext object
        StartCoroutine(StartScrapbook());
        //chosenCard.transform.position = Vector3.Lerp(chosenCard.transform.position, chosenCardPos.transform.position, 4f);
    }
    
    IEnumerator StartScrapbook()
    {
        yield return new WaitForSeconds(6f);
        memoryCard.gameObject.SetActive(false);
        memoryText.gameObject.SetActive(false);
        swirlText.gameObject.SetActive(false);
        scrapbook.SetActive(true);
        page1.SetBool("Replacing", true);
        yield return new WaitForSeconds(4f);
        memoryText.gameObject.SetActive(true);
        page1.gameObject.SetActive(false);
        //yield return new WaitForSeconds(1f);
        /*
        if (scrapbookScript.MemoryList.Count == 1)
        {
            page1.SetBool("Replacing", true);
            //triggers animation
            yield return new WaitForSeconds(4f);
            memoryText.gameObject.SetActive(true);
            page1.gameObject.SetActive(false);
        }
        else if (scrapbookScript.MemoryList.Count == 2)
        {
            page2.SetBool("Replacing", true);
            yield return new WaitForSeconds(4f);
            memoryText2.gameObject.SetActive(true);
            page2.gameObject.SetActive(false);
        }

        */
    }

    [YarnCommand("turnOffPages")]
    public void TurnOffPages()
    {
        memoryText.gameObject.SetActive(false);
        page02text.gameObject.SetActive(false);
    }
}
