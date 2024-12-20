using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject menu;
    //public GameObject inventory;

    private bool paused;

    public GameObject fighter;

    private Scene sceneName;

    public enum CharacterPOV
    {
        Fighter,
        Diviner,
        Cleric
    }

    public CharacterPOV currentPOV = CharacterPOV.Fighter;
    
    // Start is called before the first frame update
    private void Start()
    {
        paused = false;
        menu.SetActive(false);
    }

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("LandingPage");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("IntroTest");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Overworld");
        }
        /*
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("PaintingScene");
        }
        */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Debug.Log("paused");
        }

        if (paused)
        {
            
            menu.SetActive(true);
            
            //inventory.SetActive(true);
           
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false); 
            //inventory.SetActive(false);
           
            Time.timeScale = 1;
        }
    }
}
