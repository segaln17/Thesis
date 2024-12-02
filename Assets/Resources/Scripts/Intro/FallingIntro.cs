using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIntro : MonoBehaviour
{
    public float xValue;

    public float yValue;

    public float zValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(xValue, yValue, zValue);
        }
    }
}
