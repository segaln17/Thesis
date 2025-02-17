using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorActivate : MonoBehaviour
{
    public GameObject elevatorArea;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            elevatorArea.SetActive(true);
        }
    }
}
