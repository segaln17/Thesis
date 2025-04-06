using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimEvent : MonoBehaviour
{
    public GameObject threedTextObject;

    public void activateText()
    {
        threedTextObject.GetComponent<Collider>().enabled = true;
        threedTextObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void turnTextOff()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

}
