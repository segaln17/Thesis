using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    [SerializeField] Transform[] Points;

    [SerializeField] private float moveSpeed;

    private int pointsIndex;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position,
                moveSpeed * Time.deltaTime);
            // The step size is equal to speed times frame time.
            
            Vector3 relativePos = Points[pointsIndex].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 0.5f);
            
            /*float singleStep = moveSpeed * Time.deltaTime;
            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, Points[pointsIndex].transform.position, singleStep, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            //transform.rotation = Quaternion.Lerp(transform.rotation, newDirection, 0 + Time.deltaTime * 0.01f);
            transform.rotation = Quaternion.LookRotation(newDirection);*/
            
            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }
        }
    }
}
