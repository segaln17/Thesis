using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassBar : MonoBehaviour
{
    public RectTransform compassBarTransform;
    public RectTransform objectiveMarkerTransform;
    public RectTransform northMarkerTransform;
    public RectTransform southMarkerTransform;
    public RectTransform teleportMarkerTransform;

    public Transform cameraObjectTransform;
    public Transform objectiveObjectTransform;
    public float forceMagnitude = 5f;

    public AudioSource RadioDing;
    public float distance = 0f;


    public GameObject playerDiviner;
    public Rigidbody fenRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetMarkerPosition(objectiveMarkerTransform, objectiveObjectTransform.position);
        SetMarkerPosition(northMarkerTransform, Vector3.forward * 1000);
        SetMarkerPosition(southMarkerTransform, Vector3.back * 1000);


        distance = Vector2.Distance(objectiveMarkerTransform.transform.position, teleportMarkerTransform.transform.position);
        
       if(distance >= 100 && distance <= 750f)
        {
            StartCoroutine(FadeOut2(RadioDing, 2f));
        }else if(distance <= 99 && distance >= 0)
        {
            StartCoroutine(FadeIn2(RadioDing, 2f));
        }

       if(distance <=40f && distance >= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Vector3 direction = (objectiveObjectTransform.transform.position - playerDiviner.transform.position).normalized;

                fenRB.AddForce(direction * forceMagnitude, ForceMode.Impulse);
            }
        }
    }

    private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPosition)
    {
        Vector3 directionToTarget = worldPosition - cameraObjectTransform.position;
        float signedAngle = Vector3.SignedAngle(new Vector3(cameraObjectTransform.forward.x, 0, cameraObjectTransform.forward.z), new Vector3(directionToTarget.x, 0, directionToTarget.z), Vector3.up);


        float compassPosition = Mathf.Clamp(signedAngle / Camera.main.fieldOfView, -0.5f, 0.5f);
        markerTransform.anchoredPosition = new Vector2(compassBarTransform.rect.width * compassPosition, 0);
    }

    public IEnumerator FadeIn2(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        //float hubStartVolume = 1f;


        while (audioSource.volume < 1)
        {
            audioSource.volume += 1 * Time.deltaTime / FadeTime;

            yield return null;
        }
        //audioSource.Stop();
        //audioSource.volume = startVolume;
    }

    public IEnumerator FadeOut2(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        //float hubStartVolume = 1f;


        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        //audioSource.Stop();
        //audioSource.volume = startVolume;
    }

    
}
