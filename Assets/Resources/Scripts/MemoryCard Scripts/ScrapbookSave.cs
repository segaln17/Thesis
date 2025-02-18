using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrapbookSave : MonoBehaviour
{
    public GameObject scrapbook;
    
    public List<TextMeshProUGUI> MemoryList = new List<TextMeshProUGUI>();

    public TextMeshProUGUI memory;
    //public TextMeshProUGUI memory2;
    //public TextMeshProUGUI memory3;
    
    //public MemoryCardChoose memoryScript;
    // Start is called before the first frame update
    void Start()
    {
        //memoryScript.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (MemoryList.Count >= 3)
        {
            MemoryList.RemoveAt(0);
        }
        else
        {
            memory1.text = MemoryList[0].text;
            memory2.text = MemoryList[1].text;
            memory3.text = MemoryList[2].text;
        }
        */
        
        /*
        if (memoryScript.revealed == true)
        {
            //MemoryList.Add(memoryScript.memoryText);
            
        }
        */
        
        if (scrapbook.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            CloseScrapbook();
        }
    }

    public void CloseScrapbook()
    {
        scrapbook.SetActive(false);
    }
    
}
