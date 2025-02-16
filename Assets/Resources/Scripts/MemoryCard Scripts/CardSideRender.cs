using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSideRender : MonoBehaviour
{
    public Animator cardAnimator;
    public bool isRead = false;
    public Button chooseButton;
    public Button flipButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPaper()
    {
        cardAnimator.SetBool("Clicked", true);
        flipButton.enabled = false;
        isRead = true;
        chooseButton.gameObject.SetActive(true);
    }

    public void ClickTarot()
    {
        cardAnimator.SetBool("Clicked", true);
        flipButton.enabled = false;
        isRead = true;
    }
}
