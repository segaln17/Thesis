using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
  
    //public static GameManager Instance;

    [Header("Game Manager")]
    public GameObject fighterMenu;
    public GameObject divinerMenu;
    //public GameObject ClericMenu;
    //public GameObject inventory;

    public GameObject fighter;
    public GameObject diviner;
    //public GameObject divinerSprite;

    [Header("Inventory")]
    public bool paused;

    //inventorydisplay:
    public GameObject displayOverideObj;

    public GameObject displayObject;
    public GameObject displayTextPanel;
    public GameObject inventoryText;

    private InMemoryVariableStorage inMemoryVariableStorage;
    


    private Scene sceneName;

    public enum CharacterPOV
    {
        Fighter,
        Diviner,
        Cleric
    }
    [Header("Character POV")]
    public CharacterPOV currentPOV = CharacterPOV.Fighter;
    
    // Start is called before the first frame update
    private void Start()
    {
        paused = false;
        fighterMenu.SetActive(false);
        divinerMenu.SetActive(false);

    }

    void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("TitleScreen");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("LandingPage");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Introduction");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Overworld");
        }
        */
        
        /*if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Cursor.lockState = CursorLockMode.Locked;
           // Cursor.lockState = CursorLockMode.None;
            Mouse.current.WarpCursorPosition(new Vector2(Screen.width / 2, Screen.height / 2));
        }
        */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Debug.Log("paused");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Cursor.visible = !Cursor.visible;
        }

        if (paused)
        {
            if (currentPOV == CharacterPOV.Fighter)
            {
                fighterMenu.SetActive(true);
                displayOverideObj.SetActive(true);
            }
            else if (currentPOV == CharacterPOV.Diviner)
            {
                divinerMenu.SetActive(true);
                displayOverideObj.SetActive(true);
            }
            
            
            //inventory.SetActive(true);
           
            Time.timeScale = 0;
        }
        else
        {
            if (currentPOV == CharacterPOV.Fighter)
            {
                fighterMenu.SetActive(false);
                displayOverideObj.SetActive(false);
                displayObject.SetActive(false);
                displayTextPanel.SetActive(false);
                inventoryText.SetActive(false);
                SetCharacterPOV(CharacterPOV.Fighter);
                //divinerSprite.GetComponent<SpriteRenderer>().sortingOrder = 1;

            }
            else if (currentPOV == CharacterPOV.Diviner)
            {
                divinerMenu.SetActive(false);
                displayOverideObj.SetActive(false);
                displayObject.SetActive(false);
                displayTextPanel.SetActive(false);
                inventoryText.SetActive(false);
                SetCharacterPOV(CharacterPOV.Diviner);
                //divinerSprite.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            
            //inventory.SetActive(false);

            Time.timeScale = 1;
        }
    }

    public void SetCharacterPOV(CharacterPOV targetPOV)
    {

        //inMemoryVariableStorage.SetValue("$charPOV", targetPOV.ToString());
        FindObjectOfType<InMemoryVariableStorage>().SetValue("$charPOV", targetPOV.ToString());
        currentPOV = targetPOV;
    }

}
