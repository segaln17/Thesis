using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnoffobj : MonoBehaviour
{
    public void turnthisoff()
    {
        this.gameObject.SetActive(false);
    }
}
