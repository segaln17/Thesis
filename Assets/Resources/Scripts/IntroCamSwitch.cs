using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IntroCamSwitch : MonoBehaviour
{
    [Header("Cameras")] 
    public CinemachineVirtualCamera camPos01;
    public CinemachineVirtualCamera camPos02;

    public GameObject fogBlock;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.gameObject.tag == "Player")
        {
            camPos01.Priority = 2;
            camPos02.Priority = 3;
            StartCoroutine(fog());

        }
    }
    
    IEnumerator fog()
    {
        yield return new WaitForSeconds(3f);
        fogBlock.SetActive(true);
        StopCoroutine(fog());
        yield break;
    }
    
}
