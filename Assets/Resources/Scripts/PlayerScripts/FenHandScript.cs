using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FenHandScript : MonoBehaviour
{
    public GameObject fenHandUI;

    public bool isHandOut;
    // Start is called before the first frame update
    void Start()
    {
        fenHandUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentPOV == GameManager.CharacterPOV.Diviner && Input.GetKeyDown(KeyCode.Space))
        {
            isHandOut = !isHandOut;
        }

        if (isHandOut)
        {
            fenHandUI.SetActive(true);
        }
        else
        {
            fenHandUI.SetActive(false);
        }
    }
}
