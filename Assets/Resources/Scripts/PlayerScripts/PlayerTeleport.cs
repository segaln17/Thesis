using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject debugPlayer;
    public GameObject debugPlayerDiviner;

    public GameObject bonfirePos; 
    
    public GameObject lighthousePos;

    public GameObject lighthouseBottomPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            debugPlayer.transform.position = bonfirePos.transform.position;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            debugPlayer.transform.position = lighthousePos.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            debugPlayer.transform.position = lighthouseBottomPos.transform.position;
        }*/
    }
}
