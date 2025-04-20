using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class FallingImageCustomCommands : MonoBehaviour
{
    public GameObject flashImage;

    public AudioSource flashSound;
    public AudioClip dinnerBell;
    //public SpriteRenderer flashImageSprite;

    public Sprite fenImage;
    public Sprite willowImage;
    public Sprite stableImage;
    public Sprite tavernImage;
    public Sprite fishImage;
    public Sprite gardenTreeImage;
    public Sprite rookeryImage;
    public Sprite actorsImage;
    public Sprite spineImage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        flashImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [YarnCommand ("showFenImage")]
    public void ShowFenImage()
    {
        flashImage.GetComponent<Image>().sprite = fenImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }
    
    [YarnCommand ("showActorsImage")]
    public void ShowActorsImage()
    {
        flashImage.GetComponent<Image>().sprite = actorsImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }
    
    [YarnCommand ("showTavernImage")]
    public void ShowTavernImage()
    {
        flashImage.GetComponent<Image>().sprite = tavernImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }
    
    [YarnCommand ("showStableImage")]
    public void ShowStableImage()
    {
        flashImage.GetComponent<Image>().sprite = stableImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }
    
    [YarnCommand ("showWillowImage")]
    public void ShowWillowImage()
    {
        flashImage.GetComponent<Image>().sprite = willowImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }
    
    [YarnCommand ("showGardenImage")]
    public void ShowGardenImage()
    {
        flashImage.GetComponent<Image>().sprite = gardenTreeImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }
    
    [YarnCommand ("showFishImage")]
    public void ShowFishImage()
    {
        flashImage.GetComponent<Image>().sprite = fishImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }
    
    [YarnCommand ("showRookeryImage")]
    public void ShowRookeryImage()
    {
        flashImage.GetComponent<Image>().sprite = rookeryImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }
    
    [YarnCommand ("showSpineImage")]
    public void ShowSpineImage()
    {
        flashImage.GetComponent<Image>().sprite = spineImage;
        flashImage.SetActive(true);
        flashSound.PlayOneShot(dinnerBell);
    }

    [YarnCommand ("hideImage")]
    public void HideImage()
    {
        flashImage.SetActive(false);
    }
}
