using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTimer : MonoBehaviour
{
    private float secondsToWait = 180f;

    private float elapsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Mathf.Clamp(Time.deltaTime, 0f, 1f / 30f);

        if (Input.anyKey || Input.touchCount > 0)
        {
            elapsed = 0;
        }

        if (elapsed > secondsToWait)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
