using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayertoGarden : MonoBehaviour
{
    public GameObject gardenObject;
    public GameObject player;
    public float speed = 1.0f;

    void Awake()
    {
       StartCoroutine(moveIntoGarden());
    }

    private IEnumerator moveIntoGarden()
    {
        // Move our position a step closer to the target.
        var step =  speed * Time.deltaTime; // calculate distance to move
        player.transform.position = Vector3.MoveTowards(player.transform.position, gardenObject.transform.position, step);
        
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(player.transform.position, gardenObject.transform.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            gardenObject.transform.position *= -1.0f;
        }

        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
