using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
  
    public SpriteRenderer photoSpriteArea;
    public Sprite photoSprite;

    private Texture2D screenCapture;
    //private Texture2D screenCaptureSave;
    //public int xValue01;
   // public int xValue02;
    //public int xValue03;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(CapturePhoto());
        }
    }

    IEnumerator CapturePhoto()
    {
        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
        SaveTexture(_texture: screenCapture);
        //screenCaptureSave = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);;
        
    }
    

    void ShowPhoto()
    {
        photoSprite = Sprite.Create(screenCapture, new Rect(0, 0, screenCapture.width, screenCapture.height), new Vector2(.5f, .5f), 100.0f);
        //photoDisplayArea.sprite = photoSprite;
        photoSpriteArea.sprite = photoSprite;
        
    }

   public void TakePhoto()
    {
        StartCoroutine(CapturePhoto());
    }

    public void SaveTexture(Texture2D _texture)
    {
        //texture = screenCapture;
        //then Save To Disk as PNG
        byte[] bytes = _texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/SaveImages/";
        if(!Directory.Exists(dirPath)) {
            Directory.CreateDirectory(dirPath);
            Debug.Log("CreatedFolder");
        }
        File.WriteAllBytes(dirPath + "Screenshot-" + DateTime.Now.ToString(("yyyy-MM-dd-HH-mm-ss")) + ".png", bytes);
        Debug.Log("ImageSaved");
    }
}
