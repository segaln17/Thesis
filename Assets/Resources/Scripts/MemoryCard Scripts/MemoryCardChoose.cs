using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    
    //button for new card:
    public Button newCard;
    
    //button for memory card:
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
    public GameObject chosenCardPos;
    
    //scrapbook:
    public GameObject scrapbook;
    public ScrapbookSave scrapbookScript;
    
    //strings that are text for each card set:
    public string dreamerFragment01;
    public string dreamerFragment02;

    public string archaeFragment01;
    public string archaeFragment02;

    public MemoryActivation memoryActivationScript;
    
    //public int clickAmount;
    
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
        StartCoroutine("StartForget");
        memoryText.text = card01Text.text;
        RevealMemory();
    }

    public void Choose02()
    {
        isChosen = true;
        chosenCard = existingCard02;
        forgottenCard = existingCard01;
        StartCoroutine("StartForget");
        memoryText.text = card02Text.text;
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
        
    }

    public void RevealMemory()
    {
        newCard.gameObject.SetActive(false);
        chosenCard.gameObject.SetActive(false);
        memoryCard.gameObject.SetActive(true);
        revealed = true;
        if (scrapbookScript.MemoryList.Count <3)
        {
            scrapbookScript.MemoryList.Add(memoryText);
            /*
            if (scrapbookScript.MemoryList.Count == 1)
            {
                scrapbookScript.memory.text += "/n" + memoryText.text;
            }
            */
        }
        else
        {
            scrapbookScript.MemoryList.RemoveAt(0);
            scrapbookScript.MemoryList.Add(memoryText);
        }

        scrapbookScript.memory.text += memoryText.text + "\n";
        StartCoroutine(StartScrapbook());
        //chosenCard.transform.position = Vector3.Lerp(chosenCard.transform.position, chosenCardPos.transform.position, 4f);
    }
    
    IEnumerator StartScrapbook()
    {
        yield return new WaitForSeconds(6f);
        memoryCard.gameObject.SetActive(false);
        scrapbook.SetActive(true);
    }
    
    //set up next set of cards:
    public void NextSet()
    {
        //change what existingCards 01 and 02 are
        //change the text of newCard
        //change card01 and card02's memory text accordingly
        //reset positions
    }
}
