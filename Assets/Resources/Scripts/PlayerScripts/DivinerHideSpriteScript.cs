using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DivinerHideSpriteScript : MonoBehaviour
{
    public GameObject playerDiviner;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("hideFen")]
    public void HideDivinerSprite()
    {
       playerDiviner.GetComponent<SpriteRenderer>().enabled = false;
    }

    [YarnCommand("revealFen")]
    public void RevealDivinerSprite()
    {
        playerDiviner.GetComponent<SpriteRenderer>().enabled = true;
    }
}
